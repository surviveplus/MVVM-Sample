module mvvmsample {

    export class ProductPage implements IView {

        // #region IView members

        private parent: IViewPanel;
        get Parent() {
            return this.parent;
        }
        set Parent(value: IViewPanel) {
            this.parent = value;
            this.Refresh();
        }

        // #endregion

        private product: any;

        constructor(product: any) {
            this.product = product;
        }

        Refresh() {
            if (this.parent == null) return;
            this.parent.ViewContainer.children().each((index, elem) => {
                $(elem).remove();
            });
            
            this.parent.ViewContainer.append(
                "<div class='productPage'>" +
                    "<h1>Product Item</h1>" +
                    "<p>Title : <span data-bind='text:Title' /></p>" +
                    "<p>Description : <span data-bind='text:Description' /></p>" +
                    "<p>Publisher : <span data-bind='text:Publisher' /></p>" +
                    "<p>Price : <span data-bind='text:Price' /></p>" +
                    "<p>" +
                        "<a target=\"_blank\" data-bind='attr: {href:DownloadUrl}'\">Download</a> " +
                        "<a target=\"_blank\" data-bind='attr: {href:ProductUrl}'\">Open Site</a> " +
                        "<a target=\"_blank\" data-bind='attr: {href:PublisherUrl}'\">Publisher</a> " +
                    "</p>" +
                "<div>");

            ko.applyBindings(this.product, this.parent.ViewContainer.find(".productPage")[0]);

        } // end sub

    } // end class

}
