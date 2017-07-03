using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvvmSample.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Title = "Home";

            var model = new Models.HomeModel {
                Description =
                    "このプログラムは MVVM の実装方法を理解するための ASP.NET MVC アプリケーションのサンプルです。\n\n" +
                    "Web Platform Installer の様に自分がよく使う製品を登録し、一覧を表示して、後でダウンロードすることができるアプリです。\n" +
                    "ナビゲーションの [Products] ボタンから製品一覧に移動して、[New Item] ボタンを押してアイテムを追加してください。\n" +
                    "追加したアイテムはデータベースに保存されます。" +
                    "製品名のリンクをクリックするとアイテムページに移動します。[Download] リンクを押して Webサイトを開くことができます。\n\n" +
                    "このサンプルには [Edit Item] と [Delete Item] は実装されていません。ステップアップのためにこれらを実装してみましょう。",
                Version = "Ver." + Assembly.GetExecutingAssembly().GetName().Version.ToString()
            };
            return View(model);
        }
    }
}