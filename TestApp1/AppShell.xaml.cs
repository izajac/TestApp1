using System;
using System.Collections.Generic;
using TestApp1.ViewModels;
using TestApp1.Views;
using Xamarin.Forms;

namespace TestApp1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
