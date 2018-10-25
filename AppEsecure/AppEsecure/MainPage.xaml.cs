using Android.OS;
using Plugin.Geolocator;
using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppEsecure
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });
            
            BindingContext = this;
        }
        
        public bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }
        public ICommand NavigateCommand { private set; get; }

        private void Button_Clicked(object sender, EventArgs e)
        {
            messageLabel.Text = "Hola " + usernameEntry.Text;
            //return true;
        }
    }
}
