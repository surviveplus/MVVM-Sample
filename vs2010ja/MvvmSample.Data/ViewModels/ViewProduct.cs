using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Data.ViewModels
{
    /// <summary>
    /// 汎用的な View Model(VM) として使用する Product クラスです。
    /// Model(M) Product の値を画面に表示するときに使用します。
    /// </summary>
    public class ViewProduct : ViewModelBase
    {
        #region プロパティ

        public int Id { get; set; }


        private string valueOfTitle;

        [Required]
        public string Title
        {
            get { return this.valueOfTitle;}
            set { this.SetProperty(ref this.valueOfTitle, value, "Title");}
        } 

        public string ProductUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string PublisherUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }

        #endregion

        public void Initialize()
        {
            this.Title = null;
        }

        #region 静的メソッド

        /// <summary>
        /// View Model(VM) Product のプロパティの値を、Model(M) Product のプロパティにコピーします。
        /// </summary>
        /// <param name="from">View Model(VM) Product のインスタンスを指定します。</param>
        /// <param name="to">Model(M) Product のインスタンスを指定します。</param>
        public static void SetProperties(ViewProduct from, MvvmSample.Data.Product to ) {

            Func<string, string> getTrim = text => string.IsNullOrWhiteSpace(text) ? null : text.Trim();

            to.Id = from.Id;
            to.Title = getTrim(from.Title);
            to.ProductUrl = getTrim(from.ProductUrl);
            to.DownloadUrl = getTrim(from.DownloadUrl);
            to.Description = getTrim(from.Description);
            to.Publisher = getTrim(from.Publisher);
            to.PublisherUrl = getTrim(from.PublisherUrl);
            to.ImageUrl = getTrim(from.ImageUrl);

            Func<string, decimal?> toDecimal = text =>
            {
                if (string.IsNullOrWhiteSpace(text)) return null;
                if (text == "FREE") return 0;

                return Convert.ToDecimal(text.Replace(",", ""));
            };

            to.Price = toDecimal( getTrim(from.Price) );
        } // end sub

        /// <summary>
        /// Model(M) Product のプロパティの値を、View Model(VM) Product のプロパティにコピーします。
        /// </summary>
        /// <param name="from">Model(M) Product のインスタンスを指定します。</param>
        /// <param name="to">View Model(VM) Product のインスタンスを指定します。</param>
        public static void SetProperties( MvvmSample.Data.Product from, ViewProduct to)
        {
            Func<decimal?, string, string> getToString = (value, format) => value.HasValue == false ? null : value.Value.ToString(format);

            to.Id = from.Id;
            to.Title = from.Title;
            to.ProductUrl = from.ProductUrl;
            to.DownloadUrl = from.DownloadUrl;
            to.Description = from.Description;
            to.Publisher = from.Publisher;
            to.PublisherUrl = from.PublisherUrl;
            to.ImageUrl = from.ImageUrl;

            if (from.Price.HasValue && from.Price.Value <= 0)
            {
                to.Price = "FREE";
            }else
            {
                to.Price = getToString(from.Price,"C") ?? "FREE";
            } // end if

        } // end sub

        /// <summary>
        /// Model(M) Product のプロパティの値を元に、View Model(VM) Product の新しいインスタンスを初期化して返します。
        /// </summary>
        /// <param name="from">Model(M) Product のインスタンスを指定します。</param>
        /// <returns>新しい View Model(VM) Product のインスタンスを返します。</returns>
        public static ViewProduct FromProduct(MvvmSample.Data.Product from)
        {
            var to = new ViewProduct();
            ViewProduct.SetProperties(from, to);
            return to;
        } // end function
        #endregion

    } // end class
} // end namespace
