module mvvmsample {

    export class App {

        public Settings: AppSettings;

        public Start() {
            var w = new Window;
            w.Render();
            w.Start();

            var homePage = new HomePage(this.Settings);
            var productsPage = new ProductsPage(this.Settings);
            w.Frame.Show(homePage);

            var group1 = w.Ribbon.AddNewGroup();

            var homeCommand = new AppCommand("Home", "home");
            homeCommand.Action = (sender, e) => {
                w.Frame.Show(homePage);
            };
            group1.AddCommand(homeCommand);

            var productsCommand = new AppCommand("Products", "products");
            productsCommand.Action = (sender, e) => {
                w.Frame.Show(productsPage);
            };
            group1.AddCommand(productsCommand);

            var group2 = w.Ribbon.AddNewGroup();
            var refreshCommand = new AppCommand("Refresh", "refresh");
            refreshCommand.Action = (sender, e) => {

                var a: any = w.Frame.View;
                if (a.CanRefresh) {
                    var page: IPageUsingRibbon = a;
                    page.Refresh();
                } else {
                    alert("現在の表示では Refresh は実行出来ません");
                }// end if
            };
            group2.AddCommand(refreshCommand);

            var group3 = w.Ribbon.AddNewGroup();

            var newItemCommand = new AppCommand("New Item", "newItem");
            newItemCommand.Action = (sender, e) => {

                var a: any = w.Frame.View;
                if (a.CanAddNewItem) {
                    var page: IPageUsingRibbon = a;
                    page.AddNewItem();
                } else {
                    alert("現在の表示では New Item は実行出来ません");
                }// end if
            };
            group3.AddCommand(newItemCommand);

            var editItemCommand = new AppCommand("Edit Item", "editItem");
            editItemCommand.Action = (sender, e) => {

                var a: any = w.Frame.View;
                if (a.CanEditItem) {
                    var page: IPageUsingRibbon = a;
                    page.EditItem();
                } else {
                    alert("現在の表示では Edit Item は実行出来ません");
                }// end if

            };
            group3.AddCommand(editItemCommand);

            var deleteItemCommand = new AppCommand("Delete Item", "deleteItem");
            deleteItemCommand.Action = (sender, e) => {
                var a: any = w.Frame.View;
                if (a.CanDeleteItem) {
                    var page: IPageUsingRibbon = a;
                    page.DeleteItem();
                } else {
                    alert("現在の表示では Delete Item は実行出来ません");
                }// end if
            };
            group3.AddCommand(deleteItemCommand);

        }
    }
}
