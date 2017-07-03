using MvvmSample.Data;
using MvvmSample.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvvmSample.WebSpa.Controllers
{
    public class ProductsController : ApiController
    {

        [Route("api/Products/{otherOptions}")]
        public IEnumerable<ViewProduct> GetProducts( string otherOptions)
        {

            using (var db = new MvvmSampleEntities())
            {
                var results =
                    from p in (from p in db.Products select p).ToList()
                    select ViewProduct.FromProduct(p);

                return results;
            }

        }

        [Route("api/SaveProduct")]
        public Models.SaveResult SaveProduct( ViewProduct product)
        {
            using (var db = new MvvmSampleEntities())
            {
                var target = new Product();
                db.Products.Add(target);
                target.SetProperties(product);

                db.SaveChanges();
            } // end using(db)

            return new Models.SaveResult { success = true };
        } // end function
    }
}
