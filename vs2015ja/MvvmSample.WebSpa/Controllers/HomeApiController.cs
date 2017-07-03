using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace MvvmSample.WebSpa.Controllers
{
    public class HomeApiController : ApiController
    {

        [Route("api/Home/{otherOptions}")]
        public Models.HomeModel GetHome(string otherOptions)
        {
            var model = new Models.HomeModel
            {
                Description =
                    "これは MVVM の実装方法を理解するための ASP.NET SPA サンプルです。このサンプルデータは動的に Web API から取得されています。(" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ")",
                Version = "Ver." + Assembly.GetExecutingAssembly().GetName().Version.ToString()
            };

            return model;
        } // end function

    } // end class
} // end namespace
