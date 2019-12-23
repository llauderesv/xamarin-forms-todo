using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using FirstXamarinApp.Models;
using FirstXamarinApp.ViewModels;

namespace FirstXamarinApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemPageViewModel viewModel;

        public ItemDetailPage(ItemPageViewModel viewModel)
        {
            InitializeComponent();

            this.viewModel = viewModel;
            this.viewModel.Title = "Edit TODO";

            BindingContext = this.viewModel;
        }

        public async void Cancel_Clicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }

        public async void Save_Clicked(object sender, EventArgs args)
        {
            MessagingCenter.Send(this, "EditItem", viewModel.Item);
            await Navigation.PopModalAsync();
        }
    }
}