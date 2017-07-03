module mvvmsample {

    export class EditProductPage implements IView {

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
        private backtoPage: IView;
        private settings: AppSettings;

        constructor(product: any, backtoPage: IView, settings: AppSettings) {
            this.backtoPage = backtoPage;
            this.settings = settings;

            this.product = product;
            if (! this.product) {
                this.product = { "Id": "", "Title": "", "ProductUrl": "", "DownloadUrl": "", "Description": "", "Publisher": "", "PublisherUrl": "", "ImageUrl": "", "Price": "" };
            } // end if
        }

        Refresh() {
            if (this.parent == null) return;
            this.parent.ViewContainer.children().each((index, elem) => {
                $(elem).remove();
            });

            this.parent.ViewContainer.append(
                "<div class='editProductPage'>" +
                "<h1>Product Item</h1>" +
                "<input type='hidden' data-bind='value:Id' />" +
                "<p>Title : <input type='text' data-bind='value:Title' /></p>" +
                "<p>ProductUrl : <input type='text' data-bind='value:ProductUrl' /></p>" +
                "<p>DownloadUrl : <input type='text' data-bind='value:DownloadUrl' /></p>" +
                "<p>Description : <input type='text' data-bind='value:Description' /></p>" +
                "<p>Publisher : <input type='text' data-bind='value:Publisher' /></p>" +
                "<p>PublisherUrl : <input type='text' data-bind='value:PublisherUrl' /></p>" +
                "<p>Price : <input type='text' data-bind='value:Price' /></p>" +
                "<p><input class='saveButton' type='button' value='Save' /></p>" +
                "<div>");

            var s: JQueryAjaxSettings= {
                type: this.settings.PostOrGetForSaveProduct,
                url: this.settings.UriForSaveProduct,
                dataType: "json",
                timeout: 10000,
                success: (result) => {
                    if (result.success) {
                        var frame: any = this.Parent;
                        if (frame.Show) frame.Show(this.backtoPage);

                        var page: any = this.backtoPage;
                        if (page.CanRefresh) page.Refresh();

                    } else {
                        alert("error");
                    } // end if
                },
                error: (result) => {
                    alert("error");
                }
            };

            this.parent.ViewContainer.find(".saveButton").click( () => {
                s.data = this.product;
                $.ajax(s);
            });

            ko.applyBindings(this.product, this.parent.ViewContainer.find(".editProductPage")[0]);

        } // end sub

    } // end class

}
