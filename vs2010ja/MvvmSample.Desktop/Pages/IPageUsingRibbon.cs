using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Desktop.Pages
{
    interface IPageUsingRibbon
    {
        /// <summary>
        /// リフレッシュボタンを押して、ページの内容を再表示できるかどうかを取得します。
        /// </summary>
        bool CanRefresh { get;  }

        /// <summary>
        /// ページの内容を再表示します。
        /// </summary>
        void Refresh();

        bool CanAddNewItem { get; }

        void AddNewItem();

        bool CanEditItem { get; }

        void EditItem();


        bool CanDeleteItem { get; }

        void DeleteItem();

        event EventHandler SituationChanged;

    } // end interface
} // end namespace
