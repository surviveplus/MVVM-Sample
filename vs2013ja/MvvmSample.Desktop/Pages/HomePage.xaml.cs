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
    /// HomePage.xaml の相互作用ロジック
    /// </summary>
    public partial class HomePage : Page
    {

        #region コンストラクタ

        public HomePage()
        {
            InitializeComponent();
        } // end constructor

        #endregion

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = await Controllers.AboutController.GetAboutAsync();
        } // end sub

    } // end class
} // end namespace
