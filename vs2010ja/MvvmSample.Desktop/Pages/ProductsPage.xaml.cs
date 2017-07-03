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
    /// ProductsPage.xaml の相互作用ロジック
    /// </summary>
    public partial class ProductsPage : Page, IPageUsingRibbon
    {
        // インターフェイスの実装・オーバーライド

        #region IPageUsingRibbon メンバー

        public bool CanRefresh { get; private set; } //= true;

        public event EventHandler SituationChanged;

        public void Refresh()
        {
            this.DataContext = null;
            this.DataContext = Controllers.ProductsController.GetProducts();
        } // end sub

        public bool CanAddNewItem { get; private set; } //= true;

        public void AddNewItem()
        {
            if( this.ParentFrame != null ) this.ParentFrame.Navigate(new EditProductPage { ParentFrame = this.ParentFrame});
        } // end sub


        public bool CanEditItem
        {
            get
            {
                return this.mainList.SelectedIndex >=0;
            }
        } // end property

        
        public void EditItem()
        {
            // TODO: ここにアイテムの編集操作開始を実装します。
            MessageBox.Show("この機能は実装されていません。ステップアップのために実装してみてください。", "Edit Item",  MessageBoxButton.OK, MessageBoxImage.Information);
        } // end sub

        public bool CanDeleteItem
        {
            get
            {
                return this.mainList.SelectedIndex >= 0;
            }
        } // end property

        public void DeleteItem()
        {
            // TODO: ここにアイテムの削除操作開始を実装します。
            MessageBox.Show("この機能は実装されていません。ステップアップのために実装してみてください。", "Delete Item", MessageBoxButton.OK, MessageBoxImage.Information);
        } // end sub

        #endregion


        // クラスメンバ

        /// <summary>
        /// ページが表示されるフレームを取得、または設定します。
        /// </summary>
        public Frame ParentFrame { get; set; }
        
        #region コンストラクタ

        public ProductsPage()
        {
            InitializeComponent();

            this.CanRefresh = true;
            this.CanAddNewItem = true;
        } // end constructor

        #endregion

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(this.DataContext == null)
            {
                this.Refresh();
            } // end if
        } // end sub


        private void mainList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.SituationChanged != null) this.SituationChanged.Invoke(this, EventArgs.Empty);
        } // end sub

        private void SelectItem() {
            var item = this.mainList.SelectedItem as Data.ViewModels.ViewProduct;
            if( item != null)
            {
                this.ParentFrame.Navigate(new ProductPage { Product = item });
            } // end if

        } // end sub

        private void mainList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.SelectItem();
        }

        private void mainList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    this.SelectItem();
                    break;

            } // end switch
        } // end sub

    } // end class
} // end namespace
