using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Course.RealTime.Services;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;

namespace Course.RealTime
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainPageViewModel(new SignalrService());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((MainPageViewModel)this.BindingContext).Connect();
        }

     
    }
}