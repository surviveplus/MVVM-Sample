using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Data
{
    public partial class MvvmSampleEntities
    {
        /// <summary>
        /// 接続文字列を使用して、MvvmSampleEntities クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="connectionString">接続文字列を指定します。</param>
        public MvvmSampleEntities(string connectionString):base(connectionString)
        {
        } // end constructor

    } // end class
} // end namespace
