using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestApp1.Models;
using Xamarin.Forms;

namespace TestApp1.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string text;

        private string quantity;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text) && !String.IsNullOrWhiteSpace(quantity);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Quantity
        {
            get => quantity;
            set => SetProperty(ref quantity, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Text = Text,
                Quantity = Quantity
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
