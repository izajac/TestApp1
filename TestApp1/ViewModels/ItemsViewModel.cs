using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using TestApp1.Models;
using TestApp1.Views;
using Xamarin.Forms;

namespace TestApp1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {

        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command DeleteItemsCommand { get; }
        public Item CurrentItem { get; set; }
   

        public ItemsViewModel()
        {
            Title = "Shopping List";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            AddItemCommand = new Command(OnAddItem);

            DeleteItemsCommand = new Command(OnDeleteItems);

        }
        
        async Task ExecuteLoadItemsCommand()
        {
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

        public void OnAppearing()
        {
            IsBusy = true;
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
        
        public async void OnDeleteItems()
        {
            String id = null;

            //if (id != "")
            //{
            //    await DataStore.DeleteItemAsync(id);
            //    await ExecuteLoadItemsCommand();
            //} 
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("Alert", "Please select an item to remove", "OK");
            //}

            //Seems to work when no option is initially selected, after an item is deleted the
            //alert doesn't come up again
            try
            {
                id = CurrentItem.Id;
                await DataStore.DeleteItemAsync(id);
            }
            catch 
            {
                if (id == null)
                {
                    await App.Current.MainPage.DisplayAlert("Alert", "Please select an item to remove", "OK");
                }
            }
            finally
            {
                await ExecuteLoadItemsCommand();
            }

        }

    }
}