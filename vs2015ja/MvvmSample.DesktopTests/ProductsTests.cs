using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace MvvmSample.DesktopTests
{
    [CodedUITest]
    public class ProductsTests
    {
        public ProductsTests()
        {

        }

        [TestMethod]
        public void 新しいProductを追加できること()
        {
            // このテストのコードを生成するには、ショートカット メニューの [コード化された UI テストのコードの生成] をクリックし、メニュー項目の 1 つをクリックします。
            this.UIMap.AddItem();
        }

        #region 追加のテスト属性

        // テストを作成する際には、次の追加属性を使用できます:

        ////各テストを実行する前に、TestInitialize を使用してコードを実行してください 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // このテストのコードを生成するには、ショートカット メニューの [コード化された UI テストのコードの生成] をクリックし、メニュー項目の 1 つをクリックします。
        //}

        ////各テストを実行した後に、TestCleanup を使用してコードを実行してください
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // このテストのコードを生成するには、ショートカット メニューの [コード化された UI テストのコードの生成] をクリックし、メニュー項目の 1 つをクリックします。
        //}

        #endregion

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
