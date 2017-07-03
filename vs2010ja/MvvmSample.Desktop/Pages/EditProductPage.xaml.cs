using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MvvmSample.Desktop.Pages
{
    /// <summary>
    /// EditProductPage.xaml の相互作用ロジック
    /// </summary>
    public partial class EditProductPage : Page
    {
        /// <summary>
        /// ページが表示されるフレームを取得、または設定します。
        /// </summary>
        public Frame ParentFrame { get; set; }

        public MvvmSample.Data.ViewModels.ViewProduct Product { get; set; }

        public EditProductPage()
        {
            InitializeComponent();
        } // end constructor

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Product == null) {
                this.Product = new Data.ViewModels.ViewProduct();

                // .net 4.5 では自動で行われるエラー発生時のイベント処理を、自分で実装します。また、最初のエラー検証を発動するため、Initializeメソッドを実行してプロパティの割り当てとエラーイベントの発生を起こします。
                this.Product.ErrorsChanged += new EventHandler<Data.ViewModels.DataErrorsChangedEventArgs>(Product_ErrorsChanged);
                this.Product.Initialize();
            } // end if
            this.DataContext = this.Product;

            bool IsEdit = this.Product == null ? false : this.Product.Id > 0;

            this.TitleEditProductItem.Visibility = IsEdit ? Visibility.Visible : Visibility.Collapsed;
            this.TitleNewProductItem.Visibility = ! IsEdit ? Visibility.Visible : Visibility.Collapsed;
        } // end sub

        void Product_ErrorsChanged(object sender, Data.ViewModels.DataErrorsChangedEventArgs e)
        {
            // NOTE: ここは名前で探しています。ViewModel のプロパティ名 + "ValidationError" が、バリデーションエラーを表示するコントロールの名前とします。
            var t = this.FindName(e.PropertyName + "ValidationError") as TextBlock;
            var errors = this.Product.GetErrors(e.PropertyName);
            if (errors == null)
            {
                t.Text = "";
            }
            else
            {
                foreach (var item in errors)
                {
                    t.Text = item.ToString();
                }
            } // end if
        } // end sub

        private  void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.SaveButton.IsEnabled = false;
            Controllers.ProductsController.SaveProduct(this.Product);

            if (this.ParentFrame.CanGoBack)
            {
                this.ParentFrame.GoBack();
            }
        } // end sub


    } // end class
} // end namespace
