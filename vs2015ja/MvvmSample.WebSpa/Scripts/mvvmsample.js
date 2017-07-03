var mvvmsample;
(function (mvvmsample) {
    var App = (function () {
        function App() {
        }
        App.prototype.Start = function () {
            var w = new mvvmsample.Window;
            w.Render();
            w.Start();
            var homePage = new mvvmsample.HomePage(this.Settings);
            var productsPage = new mvvmsample.ProductsPage(this.Settings);
            w.Frame.Show(homePage);
            var group1 = w.Ribbon.AddNewGroup();
            var homeCommand = new mvvmsample.AppCommand("Home", "home");
            homeCommand.Action = function (sender, e) {
                w.Frame.Show(homePage);
            };
            group1.AddCommand(homeCommand);
            var productsCommand = new mvvmsample.AppCommand("Products", "products");
            productsCommand.Action = function (sender, e) {
                w.Frame.Show(productsPage);
            };
            group1.AddCommand(productsCommand);
            var group2 = w.Ribbon.AddNewGroup();
            var refreshCommand = new mvvmsample.AppCommand("Refresh", "refresh");
            refreshCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanRefresh) {
                    var page = a;
                    page.Refresh();
                }
                else {
                    alert("現在の表示では Refresh は実行出来ません");
                } // end if
            };
            group2.AddCommand(refreshCommand);
            var group3 = w.Ribbon.AddNewGroup();
            var newItemCommand = new mvvmsample.AppCommand("New Item", "newItem");
            newItemCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanAddNewItem) {
                    var page = a;
                    page.AddNewItem();
                }
                else {
                    alert("現在の表示では New Item は実行出来ません");
                } // end if
            };
            group3.AddCommand(newItemCommand);
            var editItemCommand = new mvvmsample.AppCommand("Edit Item", "editItem");
            editItemCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanEditItem) {
                    var page = a;
                    page.EditItem();
                }
                else {
                    alert("現在の表示では Edit Item は実行出来ません");
                } // end if
            };
            group3.AddCommand(editItemCommand);
            var deleteItemCommand = new mvvmsample.AppCommand("Delete Item", "deleteItem");
            deleteItemCommand.Action = function (sender, e) {
                var a = w.Frame.View;
                if (a.CanDeleteItem) {
                    var page = a;
                    page.DeleteItem();
                }
                else {
                    alert("現在の表示では Delete Item は実行出来ません");
                } // end if
            };
            group3.AddCommand(deleteItemCommand);
        };
        return App;
    })();
    mvvmsample.App = App;
})(mvvmsample || (mvvmsample = {}));
var mvvmsample;
(function (mvvmsample) {
    var EditProductPage = (function () {
        function EditProductPage(product, backtoPage, settings) {
            this.backtoPage = backtoPage;
            this.settings = settings;
            this.product = product;
            if (!this.product) {
                this.product = { "Id": "", "Title": "", "ProductUrl": "", "DownloadUrl": "", "Description": "", "Publisher": "", "PublisherUrl": "", "ImageUrl": "", "Price": "" };
            } // end if
        }
        Object.defineProperty(EditProductPage.prototype, "Parent", {
            get: function () {
                return this.parent;
            },
            set: function (value) {
                this.parent = value;
                this.Refresh();
            },
            enumerable: true,
            configurable: true
        });
        EditProductPage.prototype.Refresh = function () {
            var _this = this;
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='editProductPage'>" + "<h1>Product Item</h1>" + "<input type='hidden' data-bind='value:Id' />" + "<p>Title : <input type='text' data-bind='value:Title' /></p>" + "<p>ProductUrl : <input type='text' data-bind='value:ProductUrl' /></p>" + "<p>DownloadUrl : <input type='text' data-bind='value:DownloadUrl' /></p>" + "<p>Description : <input type='text' data-bind='value:Description' /></p>" + "<p>Publisher : <input type='text' data-bind='value:Publisher' /></p>" + "<p>PublisherUrl : <input type='text' data-bind='value:PublisherUrl' /></p>" + "<p>Price : <input type='text' data-bind='value:Price' /></p>" + "<p><input class='saveButton' type='button' value='Save' /></p>" + "<div>");
            var s = {
                type: this.settings.PostOrGetForSaveProduct,
                url: this.settings.UriForSaveProduct,
                dataType: "json",
                timeout: 10000,
                success: function (result) {
                    if (result.success) {
                        var frame = _this.Parent;
                        if (frame.Show)
                            frame.Show(_this.backtoPage);
                        var page = _this.backtoPage;
                        if (page.CanRefresh)
                            page.Refresh();
                    }
                    else {
                        alert("error");
                    } // end if
                },
                error: function (result) {
                    alert("error");
                }
            };
            this.parent.ViewContainer.find(".saveButton").click(function () {
                s.data = _this.product;
                $.ajax(s);
            });
            ko.applyBindings(this.product, this.parent.ViewContainer.find(".editProductPage")[0]);
        }; // end sub
        return EditProductPage;
    })();
    mvvmsample.EditProductPage = EditProductPage; // end class
})(mvvmsample || (mvvmsample = {}));
var mvvmsample;
(function (mvvmsample) {
    var Window = (function () {
        function Window() {
            this.selector = "#window";
            this.ribbon = new Ribbon(this, "ribbon");
            this.frame = new Frame(this, "frame");
        }
        Object.defineProperty(Window.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        Window.prototype.Render = function () {
            $("body").children().each(function (index, elem) {
                $(elem).remove();
            });
            $("body").append("<div id=\"window\"></div>");
            this.container = $(this.selector);
            this.ribbon.Render();
            this.frame.Render();
        }; // end sub
        Window.prototype.Start = function () {
            this.container = $(this.selector);
            this.ribbon.Start();
            this.frame.Start();
        }; // end sub
        Object.defineProperty(Window.prototype, "Ribbon", {
            get: function () {
                return this.ribbon;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Window.prototype, "Frame", {
            get: function () {
                return this.frame;
            },
            enumerable: true,
            configurable: true
        });
        return Window;
    })();
    mvvmsample.Window = Window; // end class
    var Ribbon = (function () {
        function Ribbon(parent, id) {
            this.itemIdex = 0;
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(Ribbon.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        Ribbon.prototype.Render = function () {
            this.parent.Container.append("<nav id='" + this.id + "'>" + "</nav>");
        }; // end sub
        Ribbon.prototype.Start = function () {
            this.container = this.parent.Container.find(this.selector);
        }; // end sub
        Ribbon.prototype.AddNewGroup = function () {
            this.itemIdex += 1;
            var id = "RibbonGroup" + this.itemIdex;
            var group = new RibbonGroup(this, id);
            group.Render();
            group.Start();
            return group;
        }; // end sub
        return Ribbon;
    })();
    mvvmsample.Ribbon = Ribbon; // end class
    var RibbonGroup = (function () {
        function RibbonGroup(parent, id) {
            this.itemIdex = 0;
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(RibbonGroup.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        RibbonGroup.prototype.Render = function () {
            this.parent.Container.append("<ul id='" + this.id + "'>" + "</ul>");
        }; // end sub
        RibbonGroup.prototype.Start = function () {
            this.container = this.parent.Container.find(this.selector);
        }; // end sub
        RibbonGroup.prototype.AddCommand = function (command) {
            this.itemIdex += 1;
            var id = "AppComand" + this.itemIdex;
            var button = new RibbonButton(this, id, command);
            button.Render();
            button.Start();
        }; // end sub
        return RibbonGroup;
    })();
    mvvmsample.RibbonGroup = RibbonGroup; // end class
    var EventArgs = (function () {
        function EventArgs() {
        }
        EventArgs.Empty = new EventArgs();
        return EventArgs;
    })();
    mvvmsample.EventArgs = EventArgs; // end class
    var AppCommand = (function () {
        function AppCommand(text, icon) {
            this.text = text;
            this.icon = icon;
        } // end constructor
        Object.defineProperty(AppCommand.prototype, "Text", {
            get: function () {
                return this.text;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(AppCommand.prototype, "Icon", {
            get: function () {
                return this.icon;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        AppCommand.prototype.Invoke = function () {
            if (this.Action != null)
                this.Action(this, EventArgs.Empty);
        }; // end sub
        return AppCommand;
    })();
    mvvmsample.AppCommand = AppCommand; // end class
    var RibbonButton = (function () {
        function RibbonButton(parent, id, command) {
            this.parent = parent;
            this.command = command;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(RibbonButton.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        RibbonButton.prototype.Render = function () {
            var iconClassName = "";
            if (this.command.Icon != null) {
                iconClassName = this.command.Icon + "Button ";
            }
            this.parent.Container.append("<li><a id='" + this.id + "' class='" + iconClassName + "linkButton' >" + this.command.Text + "</a></li>");
        }; // end sub
        RibbonButton.prototype.Start = function () {
            var _this = this;
            this.container = this.parent.Container.find(this.selector);
            this.container.click(function () {
                _this.command.Invoke();
            });
        }; // end sub
        return RibbonButton;
    })();
    mvvmsample.RibbonButton = RibbonButton; // end class
    var Frame = (function () {
        function Frame(parent, id) {
            this.parent = parent;
            this.id = id;
            this.selector = "#" + id;
        } // end constructor
        Object.defineProperty(Frame.prototype, "Container", {
            get: function () {
                return this.container;
            } // edn get
            ,
            enumerable: true,
            configurable: true
        });
        Frame.prototype.Render = function () {
            this.parent.Container.append("<article id='" + this.id + "'></article>");
        }; // end sub
        Frame.prototype.Start = function () {
            this.container = this.parent.Container.find(this.selector);
            this.viewContainer = this.container;
        }; // end sub
        Object.defineProperty(Frame.prototype, "View", {
            get: function () {
                return this.view;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(Frame.prototype, "ViewContainer", {
            get: function () {
                return this.viewContainer;
            } // end get
            ,
            enumerable: true,
            configurable: true
        });
        Frame.prototype.Show = function (view) {
            this.viewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.view = view;
            view.Parent = this;
        }; // end sub
        return Frame;
    })();
    mvvmsample.Frame = Frame; // end class
})(mvvmsample || (mvvmsample = {}));
var mvvmsample;
(function (mvvmsample) {
    var HomePage = (function () {
        function HomePage(settings) {
            this.settings = settings;
        } // constructor
        Object.defineProperty(HomePage.prototype, "Parent", {
            get: function () {
                return this.parent;
            },
            set: function (value) {
                this.parent = value;
                this.Refresh();
            },
            enumerable: true,
            configurable: true
        });
        HomePage.prototype.Refresh = function () {
            var _this = this;
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='homePage'>" + "<h1>Home</h1>" + "<p data-bind='text:Description'></p>" + "<p data-bind='text:Version'></p>" + "</div>");
            var uri = this.settings.UriForHome + "date=" + new Date().getTime();
            $.getJSON(uri).done(function (data) {
                ko.applyBindings(data, _this.parent.ViewContainer.find(".homePage")[0]);
            });
        }; // end sub
        return HomePage;
    })();
    mvvmsample.HomePage = HomePage; // end class
})(mvvmsample || (mvvmsample = {}));
var mvvmsample;
(function (mvvmsample) {
    var ProductPage = (function () {
        function ProductPage(product) {
            this.product = product;
        }
        Object.defineProperty(ProductPage.prototype, "Parent", {
            get: function () {
                return this.parent;
            },
            set: function (value) {
                this.parent = value;
                this.Refresh();
            },
            enumerable: true,
            configurable: true
        });
        ProductPage.prototype.Refresh = function () {
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='productPage'>" + "<h1>Product Item</h1>" + "<p>Title : <span data-bind='text:Title' /></p>" + "<p>Description : <span data-bind='text:Description' /></p>" + "<p>Publisher : <span data-bind='text:Publisher' /></p>" + "<p>Price : <span data-bind='text:Price' /></p>" + "<p>" + "<a target=\"_blank\" data-bind='attr: {href:DownloadUrl}'\">Download</a> " + "<a target=\"_blank\" data-bind='attr: {href:ProductUrl}'\">Open Site</a> " + "<a target=\"_blank\" data-bind='attr: {href:PublisherUrl}'\">Publisher</a> " + "</p>" + "<div>");
            ko.applyBindings(this.product, this.parent.ViewContainer.find(".productPage")[0]);
        }; // end sub
        return ProductPage;
    })();
    mvvmsample.ProductPage = ProductPage; // end class
})(mvvmsample || (mvvmsample = {}));
var mvvmsample;
(function (mvvmsample) {
    var ProductsPage = (function () {
        function ProductsPage(settings) {
            // #endregion
            // #region IPageUsingRibbon members
            this.CanRefresh = true;
            this.CanAddNewItem = true;
            this.CanEditItem = false;
            this.CanDeleteItem = false;
            this.settings = settings;
        } // constructor
        Object.defineProperty(ProductsPage.prototype, "Parent", {
            get: function () {
                return this.parent;
            },
            set: function (value) {
                this.parent = value;
                this.RefreshView();
            },
            enumerable: true,
            configurable: true
        });
        ProductsPage.prototype.Refresh = function () {
            this.data = null;
            this.RefreshView();
        }; // end sub
        ProductsPage.prototype.AddNewItem = function () {
            var frame = this.Parent;
            if (frame.Show)
                frame.Show(new mvvmsample.EditProductPage(null, this, this.settings));
        }; // end sub
        ProductsPage.prototype.EditItem = function () {
        };
        ProductsPage.prototype.DeleteItem = function () {
        };
        ProductsPage.prototype.RefreshView = function () {
            var _this = this;
            if (this.parent == null)
                return;
            this.parent.ViewContainer.children().each(function (index, elem) {
                $(elem).remove();
            });
            this.parent.ViewContainer.append("<div class='productsPage'>" + "<h1>Products</h1>" + "<table>" + "<thead>" + "<tr>" + "<th>Title</th>" + "<th>Description</th>" + "<th>Publisher</th>" + "<th>Price</th>" + "</tr>" + "</thead>" + "<tfoot></tfoot>" + "<tbody data-bind='foreach: lines'>" + "<tr data-bind='click: Clicked'>" + "<td class='nowrap' data-bind='text:Title'></td>" + "<td data-bind='text:Description'></td>" + "<td class='nowrap' data-bind='text:Publisher'></td>" + "<td class='nowrap' data-bind='text:Price'></td>" + "</tr>" + "</tbody>" + "</table>" + "<div>");
            if (this.data) {
                ko.applyBindings({ lines: this.data }, this.parent.ViewContainer.find(".productsPage")[0]);
            }
            else {
                var uri = this.settings.UriForProducts + "date=" + new Date().getTime();
                $.getJSON(uri).done(function (data) {
                    data.forEach(function (key, index, products) {
                        products[index].Clicked = function () {
                            //alert(index);
                            //alert(products[index].Title);
                            var product = products[index];
                            var frame = _this.Parent;
                            if (frame.Show)
                                frame.Show(new mvvmsample.ProductPage(product));
                        };
                    });
                    _this.data = data;
                    ko.applyBindings({ lines: data }, _this.parent.ViewContainer.find(".productsPage")[0]);
                });
            } // end if
        }; // end sub
        return ProductsPage;
    })();
    mvvmsample.ProductsPage = ProductsPage; // end class
})(mvvmsample || (mvvmsample = {}));
var mvvmsample;
(function (mvvmsample) {
    var AppSettings = (function () {
        function AppSettings() {
        }
        return AppSettings;
    })();
    mvvmsample.AppSettings = AppSettings;
})(mvvmsample || (mvvmsample = {}));
/// <reference path="../jquery/jquery.d.ts" />
/// <reference path="../knockout/knockout.d.ts" />
/// <reference path="../linq/linq.d.ts" />
/// <reference path="mvvmsample.app.ts" />
/// <reference path="mvvmsample.editproduct.ts" />
/// <reference path="mvvmsample.frame.ts" />
/// <reference path="mvvmsample.home.ts" />
/// <reference path="mvvmsample.product.ts" />
/// <reference path="mvvmsample.products.ts" />
/// <reference path="mvvmsample.settings.ts" />
