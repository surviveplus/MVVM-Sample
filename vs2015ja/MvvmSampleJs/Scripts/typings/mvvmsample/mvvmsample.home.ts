module mvvmsample {

    export class HomePage implements IView {

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

        private settings: AppSettings;

        constructor(settings: AppSettings) {
            this.settings = settings;
        } // constructor

        Refresh() {
            if (this.parent == null) return;

            this.parent.ViewContainer.children().each((index, elem) => {
                $(elem).remove();
            });

            this.parent.ViewContainer.append(
                "<div class='homePage'>"+
                    "<h1>Home</h1>" +
                    "<p data-bind='text:Description'></p>" +
                    "<p data-bind='text:Version'></p>" + 
                "</div>");

            var uri = this.settings.UriForHome + "date=" + new Date().getTime();
            $.getJSON(uri).done((data) => {
                ko.applyBindings(data, this.parent.ViewContainer.find(".homePage")[0]);
            });

        } // end sub

    } // end class
}
