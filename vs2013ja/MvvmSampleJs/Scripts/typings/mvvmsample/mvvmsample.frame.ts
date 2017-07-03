module mvvmsample {

    export interface IAppControl {
        Container: JQuery;
        Render();
        Start();
    } // end interface

    export interface IViewPanel {
        ViewContainer: JQuery;
    } // end interface

    export interface IView {
        Parent: IViewPanel;
    } // end interface

    export interface IPageUsingRibbon {

        CanRefresh: boolean;
        Refresh();

        CanAddNewItem: boolean;
        AddNewItem();

        CanEditItem: boolean;
        EditItem();

        CanDeleteItem: boolean;
        DeleteItem();

        SituationChanged: EventHandler;
    } // end interface

    export class Window implements IAppControl{

        // #region IAppControl members

        private selector: string;
        private container: JQuery;

        get Container(): JQuery {
            return this.container;
        } // edn get

        public Render() {
            $("body").children().each((index, elem) => {
                $(elem).remove();
            });

            $("body").append("<div id=\"window\"></div>");
            this.container = $(this.selector);

            this.ribbon.Render();
            this.frame.Render();
        } // end sub

        public Start() {
            this.container = $(this.selector);

            this.ribbon.Start();
            this.frame.Start();
        } // end sub

        // #endregion

        private ribbon: Ribbon;
        public get Ribbon() {
            return this.ribbon;
        }

        private frame: Frame;
        public get Frame() {
            return this.frame;
        }

        constructor() {
            this.selector = "#window";
            
            this.ribbon = new Ribbon(this, "ribbon");
            this.frame = new Frame(this, "frame");
        }

    } // end class

    export class Ribbon implements IAppControl {

        // #region IAppControl members

        private selector: string;
        private container: JQuery;

        get Container(): JQuery {
            return this.container;
        } // edn get

        public Render() {
            this.parent.Container.append(
                "<nav id='" + this.id + "'>" +
                "</nav>");
        } // end sub

        public Start() {
            this.container = this.parent.Container.find(this.selector);
        } // end sub

        // #endregion

        private parent: Window;
        private id: string;

        constructor(parent: Window, id: string) {
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor

        private itemIdex: number = 0;

        public AddNewGroup(): RibbonGroup {

            this.itemIdex += 1;
            var id = "RibbonGroup" + this.itemIdex;

            var group = new RibbonGroup(this, id);
            group.Render();
            group.Start();
            return group;
        } // end sub

    } // end class


    export class RibbonGroup implements IAppControl {

        // #region IAppControl members

        private selector: string;
        private container: JQuery;

        get Container(): JQuery {
            return this.container;
        } // edn get

        public Render() {
            this.parent.Container.append(
                "<ul id='" + this.id + "'>" +
                "</ul>");
        } // end sub

        public Start() {
            this.container = this.parent.Container.find(this.selector);
        } // end sub

        // #endregion

        private parent: Ribbon;
        private id: string;

        constructor(parent: Ribbon, id: string) {
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor

        private itemIdex: number = 0;

        public AddCommand(command: AppCommand) {

            this.itemIdex += 1;
            var id = "AppComand" + this.itemIdex;

            var button = new RibbonButton(this, id, command);
            button.Render();
            button.Start();
        } // end sub

    } // end class


    export class EventArgs {
        static Empty: EventArgs = new EventArgs();
    } // end class

    export interface EventHandler {
        (sender: any, e: EventArgs): void;
    } // end interface

    export class AppCommand {

        private text: string;

        public get Text() {
            return this.text;
        } // end get

        private icon: string;

        public get Icon() {
            return this.icon;
        } // end get

        public Action: EventHandler;

        constructor(text: string, icon: string) {
            this.text = text;
            this.icon = icon;
        } // end constructor

        public Invoke() {
            if (this.Action != null) this.Action(this, EventArgs.Empty);
        } // end sub

    } // end class

    export class RibbonButton implements IAppControl{

        // #region IAppControl members

        private selector: string;
        private container: JQuery;

        get Container(): JQuery {
            return this.container;
        } // edn get

        public Render() {
            var iconClassName = "";
            if (this.command.Icon != null) {
                iconClassName = this.command.Icon + "Button ";
            }

            this.parent.Container.append(
                "<li><a id='" + this.id + "' class='" + iconClassName + "linkButton' >" +
                this.command.Text +
                "</a></li>");
        } // end sub

        public Start() {
            this.container = this.parent.Container.find(this.selector);

            this.container.click(() => {
                this.command.Invoke();
            });
        } // end sub

        // #endregion
         
        private parent: RibbonGroup;
        private id: string;
        private command: AppCommand;

        constructor(parent: RibbonGroup, id: string, command: AppCommand) {
            this.parent = parent;
            this.command = command;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor

    } // end class


    export class Frame implements IAppControl, IViewPanel {

        // #region IAppControl members

        private selector: string;
        private container: JQuery;

        get Container(): JQuery {
            return this.container;
        } // edn get

        public Render() {
            this.parent.Container.append(
                "<article id='" + this.id + "'></article>");
        } // end sub

        public Start() {
            this.container = this.parent.Container.find(this.selector);
            this.viewContainer = this.container;
        } // end sub

        // #endregion

        // #region IViewPanel

        private view: IView;
        public get View() {
            return this.view;
        } // end get

        private viewContainer: JQuery;

        public get ViewContainer(): JQuery {
            return this.viewContainer;
        } // end get

        // #endregion

        private id: string;
        private parent: Window;

        constructor(parent: Window, id: string) {
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor

        public Show(view: IView) {
            this.viewContainer.children().each((index, elem) => {
                $(elem).remove();
            });

            this.view = view;
            view.Parent = this;
        } // end sub
    } // end class

}