using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Desktop.Controllers
{
    public static class UriController
    {
        public static void OpenUri( Uri uri)
        {
            System.Diagnostics.Process.Start(uri.ToString());
        } // end function

    } // end class
} // end namespace
