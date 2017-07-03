$().ready(() => {

    var settings: mvvmsample.AppSettings = {
        UriForHome: "api/Home.json?",
        UriForProducts: "api/Products.json?",
        UriForSaveProduct : "api/saveproduct.json",
        PostOrGetForSaveProduct : "get"
    };

    var app = new mvvmsample.App;
    app.Settings = settings;
    app.Start();

});