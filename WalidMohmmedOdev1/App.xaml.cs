namespace WalidMohmmedOdev1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        private async void OnVicutKitleIndeksiClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//VicutKitleIndeksiPage");
        }

    }
}