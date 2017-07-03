using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Desktop.ViewModels
{
    public class SampleProductCollection : List<SampleProduct> { }

    public class SampleProduct
    {
        #region プロパティ

        public string Title { get; set; }
        public string ProductUrl { get; set; }
        public string DownloadUrl { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string PublisherUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }

        #endregion

    } // end class
} // end namespace
