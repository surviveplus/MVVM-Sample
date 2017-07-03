using MvvmSample.Data;
using MvvmSample.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvvmSample.WebMvc.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.Title = "Products";

            using (var db = new MvvmSampleEntities())
            {
                var results =
                    from p in (from p in db.Products select p).ToList()
                    select Data.ViewModels.ViewProduct.FromProduct(p);

                return View(results);
            }
        } // end function

        // GET: Item/10
        public ActionResult Item(int id)
        {
            ViewBag.Title = "Product Item";

            using (var db = new MvvmSampleEntities())
            {
                var results =
                    from p in (from p in db.Products where p.Id == id select p).ToList()
                    select Data.ViewModels.ViewProduct.FromProduct(p);

                var item = results.FirstOrDefault();

                if ( item == null)
                {
                    // このサンプルでは、指定された Id の Product が見つからないときに、Productsページにリダイレクトします。
                    //「見つかりません」ページを表示する場合は、専用のページにリダイレクトするように変更します。
                    return new RedirectResult("~/Products");
                } // end if

                return View(item);
            }
        } // end function

        // GET: NewItem
        public ActionResult NewItem()
        {
            ViewBag.Title = "New Product Item";
            return View(new ViewProduct {Title="" });
        } // end function

        // POST: NewItem
        [HttpPost]
        public ActionResult NewItem(ViewProduct product)
        {
            ViewBag.Title = "New Product Item";

            if (ModelState.IsValid == false) return View(product);

            using (var db = new MvvmSampleEntities())
            {
                var target = new Product();
                db.Products.Add(target);
                target.SetProperties(product);

                db.SaveChanges();
            } // end using(db)

            // このサンプルでは、製品の登録が完了すると、Productsページにリダイレクトします。
            //「登録しました」ページを表示する場合は、そのことを表示するビューの表示を用意してViewを返すように変更します。
            return new RedirectResult("~/Products");
        } // end function

    } // end class
} // end namespace