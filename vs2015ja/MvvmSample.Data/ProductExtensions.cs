using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Data
{

    /// <summary>
    /// Model(M) Product クラスに対する拡張メソッドを司るクラスです。
    /// </summary>
    public static class ProductExtensions
    {
        #region 拡張メソッド

        /// <summary>
        /// View Model(VM) Product のプロパティの値を、Model(M) Product のプロパティにコピーします。
        /// </summary>
        /// <param name="me">Model(M) Product のインスタンスを指定します。</param>
        /// <param name="from">View Model(VM) Product のインスタンスを指定します。</param>
        public static void SetProperties(this Product me, MvvmSample.Data.ViewModels.ViewProduct from)
        {
            MvvmSample.Data.ViewModels.ViewProduct.SetProperties(from, me);
        } // end sub

        #endregion

    } // end class
} // end namespace
