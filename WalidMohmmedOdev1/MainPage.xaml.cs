using System;
using Microsoft.Maui.Controls;
namespace WalidMohmmedOdev1

{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnVicutKitleIndeksiClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//VicutKitleIndeksiPage");
        }
    }
}