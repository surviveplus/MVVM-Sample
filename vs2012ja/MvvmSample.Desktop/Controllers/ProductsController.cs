using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmSample.Data;
using MvvmSample.Data.ViewModels;

namespace MvvmSample.Desktop.Controllers
{
    public static class ProductsController
    {
        public static async Task<IEnumerable<ViewProduct>> GetProductsAsync()
        {
            return await Task.Run(() => {
                using (var db = new MvvmSampleEntities())
                {
                    var results =
                        from p in  (from  p in db.Products select p).ToList()
                        select Data.ViewModels.ViewProduct.FromProduct(p);

                    return results.ToList();
                }
            });
        } // end function

        public static async Task SaveProductAsync( ViewProduct product )
        {
            using (var db = new MvvmSampleEntities())
            {
                Product target = null;
                if( product.Id > 0)
                {
                    target = (from p in db.Products where p.Id == product.Id select p).FirstOrDefault();
                }// end if

                if( target == null)
                {
                    target = new Product();
                    db.Products.Add(target);
                } // end if

                target.SetProperties(product);

                await db.SaveChangesAsync();
            } // end using(db)
        } // end function

    } // end class
} // end namespace
