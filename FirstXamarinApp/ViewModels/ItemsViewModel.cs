using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using FirstXamarinApp.Models;
using FirstXamarinApp.Views;
using System.Linq;

namespace FirstXamarinApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            SubscribeToNewItemPage();

            SubscribeToItemDetailPage();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void SubscribeToNewItemPage()
        {
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        private void SubscribeToItemDetailPage()
        {
            MessagingCenter.Subscribe<ItemDetailPage, Item>(this, "EditItem", async (obj, item) =>
            {
                var updatedItem = item as Item;
                var oldItem = Items.Where((Item arg) => arg.Id == updatedItem.Id).FirstOrDefault();
                Items.Remove(oldItem);
                Items.Add(updatedItem);

                await DataStore.UpdateItemAsync(updatedItem);
            });
        }
    }
}
