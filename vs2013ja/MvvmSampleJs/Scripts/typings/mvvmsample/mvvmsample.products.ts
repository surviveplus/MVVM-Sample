module mvvmsample {

    export class ProductsPage implements IView, IPageUsingRibbon {

        // #region IView members

        private parent: IViewPanel;
        get Parent() {
            return this.parent;
        }
        set Parent(value: IViewPanel) {
            this.parent = value;
            this.RefreshView();
        }

        // #endregion

        // #region IPageUsingRibbon members

        CanRefresh: boolean = true;

        Refresh() {
            this.data = null;
            this.RefreshView();
        } // end sub

        CanAddNewItem: boolean = true;

        AddNewItem() {
            var frame: any = this.Parent;
            if (frame.Show) frame.Show(new mvvmsample.EditProductPage(null, this, this.settings));
        } // end sub

        CanEditItem: boolean = false;
        EditItem() { }

        CanDeleteItem: boolean = false;
        DeleteItem() { }

        SituationChanged: EventHandler;

        // #endregion

        private settings: AppSettings;

        constructor(settings: AppSettings) {
            this.settings = settings;
        } // constructor

        private data: any;

        RefreshView() {
            if (this.parent == null) return;
            this.parent.ViewContainer.children().each((index, elem) => {
                $(elem).remove();
            });

            this.parent.ViewContainer.append(
                "<div class='productsPage'>" +
                "<h1>Products</h1>" +
                "<table>" +
                "<thead>" +
                "<tr>" +
                "<th>Title</th>" +
                "<th>Description</th>" +
                "<th>Publisher</th>" +
                "<th>Price</th>" +
                "</tr>" +
                "</thead>" +
                "<tfoot></tfoot>" +
                "<tbody data-bind='foreach: lines'>" +
                "<tr data-bind='click: Clicked'>" +
                "<td class='nowrap' data-bind='text:Title'></td>" +
                "<td data-bind='text:Description'></td>" +
                "<td class='nowrap' data-bind='text:Publisher'></td>" +
                "<td class='nowrap' data-bind='text:Price'></td>" +
                "</tr>" +
                "</tbody>" +
                "</table>" +
                "<div>");

            if (this.data) {
                ko.applyBindings({ lines: this.data }, this.parent.ViewContainer.find(".productsPage")[0]);

            } else {
                var uri = this.settings.UriForProducts + "date=" + new Date().getTime();
                $.getJSON(uri).done((data) => {

                    data.forEach((key, index, products) => {
                        products[index].Clicked = () => {
                            //alert(index);
                            //alert(products[index].Title);

                            var product = products[index];
                            var frame: any = this.Parent;
                            if (frame.Show) frame.Show(new mvvmsample.ProductPage(product));

                        };
                    });
                    this.data = data;
                    ko.applyBindings({ lines: data }, this.parent.ViewContainer.find(".productsPage")[0]);
                });
            } // end if


        } // end sub


    } // end class
}
