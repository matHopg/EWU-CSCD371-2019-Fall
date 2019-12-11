using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable CS8602

namespace ShoppingList.Tests
{
    [TestClass]
    public class MainWindowViewModelTests
    {
        [TestMethod]
        public void MainWindowViewModel_OnAddItem()
        {
            var model = new MainWindowViewModel();
            model.NewShopItemName = "test";
            int initialCount = model.ShopItems.Count;
            model.AddShopItem.Execute(null);
            Assert.AreEqual(initialCount + 1, model.ShopItems.Count);
        }

        [TestMethod]
        public void MainWindowViewModel_OnAddItemNoName()
        {
            var model = new MainWindowViewModel();
            model.NewShopItemName = "";
            int initialCount = model.ShopItems.Count;
            model.AddShopItem.Execute(null);
            Assert.AreEqual(initialCount, model.ShopItems.Count);
        }
    }
}