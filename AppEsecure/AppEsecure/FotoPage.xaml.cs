using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEsecure
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FotoPage : ContentPage
	{
		public FotoPage ()
        {
            InitializeComponent();

            CameraButton.Clicked += CameraButton_Clicked;
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

                if (photo != null)
                    PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });
            }
            catch (Plugin.Media.Abstractions.MediaPermissionException)
            {
                await DisplayAlert("No tienes permiso", "Camera Permission", "cancel");
            }
        }
    }
}