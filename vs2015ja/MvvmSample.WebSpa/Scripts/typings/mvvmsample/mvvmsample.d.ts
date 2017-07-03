/// <reference path="../jquery/jquery.d.ts" />
/// <reference path="../knockout/knockout.d.ts" />
/// <reference path="../linq/linq.d.ts" />
declare module mvvmsample {
    class App {
        Settings: AppSettings;
        Start(): void;
    }
}
declare module mvvmsample {
    class EditProductPage implements IView {
        private parent;
        Parent: IViewPanel;
        private product;
        private backtoPage;
        private settings;
        constructor(product: any, backtoPage: IView, settings: AppSettings);
        Refresh(): void;
    }
}
declare module mvvmsample {
    interface IAppControl {
        Container: JQuery;
        Render(): any;
        Start(): any;
    }
    interface IViewPanel {
        ViewContainer: JQuery;
    }
    interface IView {
        Parent: IViewPanel;
    }
    interface IPageUsingRibbon {
        CanRefresh: boolean;
        Refresh(): any;
        CanAddNewItem: boolean;
        AddNewItem(): any;
        CanEditItem: boolean;
        EditItem(): any;
        CanDeleteItem: boolean;
        DeleteItem(): any;
        SituationChanged: EventHandler;
    }
    class Window implements IAppControl {
        private selector;
        private container;
        Container: JQuery;
        Render(): void;
        Start(): void;
        private ribbon;
        Ribbon: Ribbon;
        private frame;
        Frame: Frame;
        constructor();
    }
    class Ribbon implements IAppControl {
        private selector;
        private container;
        Container: JQuery;
        Render(): void;
        Start(): void;
        private parent;
        private id;
        constructor(parent: Window, id: string);
        private itemIdex;
        AddNewGroup(): RibbonGroup;
    }
    class RibbonGroup implements IAppControl {
        private selector;
        private container;
        Container: JQuery;
        Render(): void;
        Start(): void;
        private parent;
        private id;
        constructor(parent: Ribbon, id: string);
        private itemIdex;
        AddCommand(command: AppCommand): void;
    }
    class EventArgs {
        static Empty: EventArgs;
    }
    interface EventHandler {
        (sender: any, e: EventArgs): void;
    }
    class AppCommand {
        private text;
        Text: string;
        private icon;
        Icon: string;
        Action: EventHandler;
        constructor(text: string, icon: string);
        Invoke(): void;
    }
    class RibbonButton implements IAppControl {
        private selector;
        private container;
        Container: JQuery;
        Render(): void;
        Start(): void;
        private parent;
        private id;
        private command;
        constructor(parent: RibbonGroup, id: string, command: AppCommand);
    }
    class Frame implements IAppControl, IViewPanel {
        private selector;
        private container;
        Container: JQuery;
        Render(): void;
        Start(): void;
        private view;
        View: IView;
        private viewContainer;
        ViewContainer: JQuery;
        private id;
        private parent;
        constructor(parent: Window, id: string);
        Show(view: IView): void;
    }
}
declare module mvvmsample {
    class HomePage implements IView {
        private parent;
        Parent: IViewPanel;
        private settings;
        constructor(settings: AppSettings);
        Refresh(): void;
    }
}
declare module mvvmsample {
    class ProductPage implements IView {
        private parent;
        Parent: IViewPanel;
        private product;
        constructor(product: any);
        Refresh(): void;
    }
}
declare module mvvmsample {
    class ProductsPage implements IView, IPageUsingRibbon {
        private parent;
        Parent: IViewPanel;
        CanRefresh: boolean;
        Refresh(): void;
        CanAddNewItem: boolean;
        AddNewItem(): void;
        CanEditItem: boolean;
        EditItem(): void;
        CanDeleteItem: boolean;
        DeleteItem(): void;
        SituationChanged: EventHandler;
        private settings;
        constructor(settings: AppSettings);
        private data;
        RefreshView(): void;
    }
}
declare module mvvmsample {
    class AppSettings {
        UriForHome: string;
        UriForProducts: string;
        UriForSaveProduct: string;
        PostOrGetForSaveProduct: string;
    }
}
