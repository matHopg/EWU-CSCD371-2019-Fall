using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingList
{
    public class ShopItem
    {
        public string ShopItemName { get; set; }

        public ShopItem(string name)
        {
            ShopItemName = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
