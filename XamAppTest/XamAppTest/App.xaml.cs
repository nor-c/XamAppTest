using System;
using XamAppTest.Pages;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAppTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var accessToken = Preferences.Get("accessToken", string.Empty);
            if (string.IsNullOrEmpty(accessToken))
            {
                MainPage = new NavigationPage(new RegisterPage());
            }
            else
            {
                MainPage = new NavigationPage(new HomePage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
