using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamAppTest.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAppTest.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void TapSignup_OnTapped(object sender, EventArgs e)
        {
            var response = await ApiService.RegisterUser(EntUsername.Text, EntEmail.Text, EntPassword.Text);
            if (response)
            {
                await DisplayAlert("", "Your account has been created", "Ok");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("", "Please complete the required fields", "Ok");
            }
        }

        private async void SpanSignin_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}