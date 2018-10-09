using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Newtonsoft.Json;
using EsecureModel.Exam;
using AppEsecure.Helper;
using EsecureModel.Planificacion;

namespace AppEsecure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public HttpClient _client;
        List<Test> t = new List<Test>();

        string lista = "";
        public Page2()
        {
            InitializeComponent();
        }
 
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/tests");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/planes");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/tests/2");

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var lala = await JsonHelper.GetStringFromJson("http://18.231.176.208/gemba/api/planes");
            var listaPlanes = JsonConvert.DeserializeObject<IList<Plan>>(lala);
            lst.ItemsSource = listaPlanes;
            // var imgsource = "https://image.flaticon.com/icons/svg/1001/1001044.svg";
            BindingContext = this;
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            var item = (Plan) lst.SelectedItem;
            messageLabel.Text = "OnItemSelected -> ID: " + item.PlanID + " Nombre: " + item.NombrePlan;
        }
    }
}