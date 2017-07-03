using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MvvmSample.Desktop.Controllers
{
    public static class AboutController
    {
        public static ViewModels.About GetAbout()
        {
            return new ViewModels.About {
                Description = 
                "このプログラムは MVVM の実装方法を理解するための WPF アプリケーションのサンプルです。\n\n" +
                "Web Platform Installer の様に自分がよく使う製品を登録し、一覧を表示して、後でダウンロードすることができるアプリです。\n" +
                "リボンの [Products] ボタンから製品一覧に移動して、[Add New Item] ボタンを押してアイテムを追加してください。\n" +
                "追加したアイテムはデータベースに保存されます。[Refresh] ボタンで一覧の表示を更新すると、登録したアイテムが表示されます。\n" + 
                "ダブルクリックするとアイテムページに移動します。[Download] ボタンを押して Webサイトを開くことができます。\n\n" +
                "このサンプルには [Edit Item] と [Delete Item] は実装されていません。ステップアップのためにこれらを実装してみましょう。" , 
                Version = "Ver." + Assembly.GetExecutingAssembly().GetName().Version.ToString() };
        } // end function
        
    } // end class
} // end namespace
