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
            } // end if
            this.DataContext = this.Product;

            bool IsEdit = this.Product?.Id > 0;

            this.TitleEditProductItem.Visibility = IsEdit ? Visibility.Visible : Visibility.Collapsed;
            this.TitleNewProductItem.Visibility = ! IsEdit ? Visibility.Visible : Visibility.Collapsed;
        } // end sub

        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.SaveButton.IsEnabled = false;
            await Controllers.ProductsController.SaveProductAsync(this.Product);

            if (this.ParentFrame.CanGoBack)
            {
                this.ParentFrame.GoBack();
            }
        } // end sub


    } // end class
} // end namespace
