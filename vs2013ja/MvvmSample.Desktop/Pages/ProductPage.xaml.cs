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
    /// ProductPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ProductPage : Page
    {
        public MvvmSample.Data.ViewModels.ViewProduct Product { get; set; }

        public ProductPage()
        {
            InitializeComponent();
        } // end constructor

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this.Product;

            this.DownloadButton.IsEnabled = this.Product == null ? false : ! string.IsNullOrWhiteSpace(this.Product.DownloadUrl);
            this.OpenProductSiteButton.IsEnabled = this.Product == null ? false : ! string.IsNullOrWhiteSpace(this.Product.ProductUrl) ;
            this.OpenPublisherSiteButton.IsEnabled = this.Product == null ? false : ! string.IsNullOrWhiteSpace(this.Product.PublisherUrl);
        } // end sub

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri =null;
            if( Uri.TryCreate( this.Product == null ? null : this.Product.DownloadUrl, UriKind.Absolute,out uri))
            {
                await Controllers.UriController.OpenUriAsync(uri);
            } // end if
        } // end sub

        private async void OpenProductSiteButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = null;
            if (Uri.TryCreate(this.Product == null ? null: this.Product.ProductUrl, UriKind.Absolute, out uri))
            {
                await Controllers.UriController.OpenUriAsync(uri);
            } // end if

        } // end sub

        private async void OpenPublisherSiteButton_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = null;
            if (Uri.TryCreate(this.Product == null ? null : this.Product.PublisherUrl, UriKind.Absolute, out uri))
            {
                await Controllers.UriController.OpenUriAsync(uri);
            } // end if

        } // end sub


    } // end class
} // end namespace
