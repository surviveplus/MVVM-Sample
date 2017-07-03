using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvvmSample.Data.ViewModels;
using MvvmSample.WebMvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvvmSample.WebMvc.Controllers.Tests
{
    [TestClass()]
    public class ProductsControllerTests
    {
        [TestMethod()]
        public void Item_異常系_指定されたIdのProductが見つからないときはリダイレクト()
        {

            using (var c = new ProductsController())
            {
                var id = -1;
                var result = c.Item(id);

                var redirect = result as RedirectResult;
                Assert.IsNotNull(redirect);
                Assert.AreEqual("~/Products", redirect.Url);

            } // end using(c)

        } // end function

        [TestMethod()]
        public void Item_正常_指定されたIdのProductが見つかったときProductがModelのViewを返す()
        {

            // TODO: このテストを成功させるには、単体テストのサンプル同様に、テスト前にデータベースの準備を行う実装が必要です。

            using (var c = new ProductsController())
            {
                var id = 1;
                var result = c.Item(id);

                var view = result as ViewResult;
                Assert.IsNotNull(view);

                var m = view.Model as ViewProduct;
                Assert.IsNotNull(m);

                Assert.AreEqual(1, m.Id);
                Assert.AreEqual("UnitTestSample", m.Title);
            } // end using(c)

        } // end function


    } // end class
} // end namespace