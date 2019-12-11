
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
namespace ShoppingList
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<ShopItem> ShopItems { get; } = new ObservableCollection<ShopItem>();
        private ShopItem? _SelectedShopItem;
        private string _NewShopItemName;
        public RelayCommand? AddShopItem { get; }
        public ShopItem? SelectedShopItem { get => _SelectedShopItem; set => Set(ref _SelectedShopItem, value); }
        public string NewShopItemName { get => _NewShopItemName; set => Set(ref _NewShopItemName, value); }

        public MainWindowViewModel()
        {
            AddShopItem = new RelayCommand(OnAddItem);
            _NewShopItemName = "";
        }

        private void OnAddItem()
        {
            if (!string.IsNullOrWhiteSpace(NewShopItemName))
            {
                var newItem = new ShopItem(NewShopItemName);
                ShopItems.Add(newItem);
                SelectedShopItem = newItem;
                NewShopItemName = "";
            }
        }
    }
}


