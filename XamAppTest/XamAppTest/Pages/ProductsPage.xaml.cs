using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamAppTest.Models;
using XamAppTest.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamAppTest.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        public ObservableCollection<Product> ProductCollection;
        public ProductsPage()
        {
            InitializeComponent();
            ProductCollection = new ObservableCollection<Product>();
            GetProducts();

        }

        private void TapLogout_OnTapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new RegisterPage());
        }

        private async void GetProducts()
        {
            var products = await ApiService.GetProduct();
            foreach (var product in products)
            {
                ProductCollection.Add(product);
            }
            CvProducts.ItemsSource = ProductCollection;
        }
    }
}