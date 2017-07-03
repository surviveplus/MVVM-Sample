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
using Microsoft.Windows.Controls.Ribbon;

namespace MvvmSample.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        #region コンストラクタ

        public MainWindow()
        {
            InitializeComponent();

            // ページの初期化
            this.products.ParentFrame = this.MainFrame;
        } // end constructor

        #endregion

        #region ウィンドウ表示とフレームナビゲーションの処理

        /// <summary>
        /// ホームページのインスタンスです。
        /// </summary>
        private Pages.HomePage home = new Pages.HomePage();

        /// <summary>
        /// 製品一覧ページのインスタンスです。
        /// コンストラクタでプロパティを初期化しています。
        /// </summary>
        private Pages.ProductsPage products = new Pages.ProductsPage();

        /// <summary>
        /// ウィンドウが表示されたときの処理を実行します。ホームページを表示します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(this.home);
        } // end sub

        private void MainFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            if(page != null)
            {
                page.SituationChanged -= Page_SituationChanged;
            } // end if
        } // end sub

        /// <summary>
        /// フレームのナビゲーションが完了したときの処理を実行します。リボンボタンの表示制御を行います。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            if (page != null)
            {
                page.SituationChanged += Page_SituationChanged;
            } // end if

            this.RefreshRibbon();
        } // end sub

        private void Page_SituationChanged(object sender, EventArgs e)
        {
            this.RefreshRibbon();
        } // end sub

        /// <summary>
        /// 現在表示されているページの状態に応じて、リボンの表示を最新の状態に更新します。
        /// </summary>
        private void RefreshRibbon()
        {
            this.GoBackButton.IsEnabled = this.MainFrame.CanGoBack;

            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            this.RefreshButton.IsEnabled = page == null ? false : page.CanRefresh ;
            this.AddNewItemButton.IsEnabled = page == null ? false : page.CanAddNewItem ;
            this.EditItemButton.IsEnabled = page == null ? false :page.CanEditItem ;
            this.DeleteItemButton.IsEnabled = page == null ? false : page.CanDeleteItem;
        } // end sub

        #endregion

        #region リボンボタン イベント処理

        /// <summary>
        /// リボン［Back］ボタンが押されたときの処理を実行します。
        /// 前のページに戻れるときは、戻ります。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if( this.MainFrame.CanGoBack )
            {
                this.MainFrame.GoBack();
            } // end if
        } // end sub

        /// <summary>
        /// リボン［Home］ボタンが押されたときの処理を実行します。
        /// ホームページを表示します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(this.home);
        } // end sub

        /// <summary>
        /// リボン［Products］ボタンが押されたときの処理を実行します。
        /// 製品一覧ページを表示します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoProductsButton_Click(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(this.products);
        } // end sub

        /// <summary>
        /// リボン［Refresh］ボタンが押されたときの処理を実行します。
        /// 可能な場合、ページの内容を再表示します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            if( page == null ? false : page.CanRefresh )
            {
                page.Refresh();
            } // end if
        } // end sub

        /// <summary>
        /// リボン［Add New Item］ボタンが押されたときの処理を実行します。
        /// 可能な場合、新しいアイテムを追加する操作を開始します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewItemButton_Click(object sender, RoutedEventArgs e)
        {
            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            if (page == null ? false : page.CanAddNewItem)
            {
                page.AddNewItem();
            } // end if            
        } // end sub

        /// <summary>
        /// リボン［Edit Item］ボタンが押されたときの処理を実行します。
        /// 可能な場合、アイテムを編集する操作を開始します。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditItemButton_Click(object sender, RoutedEventArgs e)
        {
            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            if (page == null ? false : page.CanEditItem )
            {
                page.EditItem();
            } // end if
        } // end sub

        #endregion

        private void DeleteItemButton_Click(object sender, RoutedEventArgs e)
        {
            var page = this.MainFrame.Content as Pages.IPageUsingRibbon;
            if (page == null ? false : page.CanDeleteItem )
            {
                page.DeleteItem();
            } // end if

        } // end sub

    } // end class
} // end namespace
