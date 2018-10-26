using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Newtonsoft.Json;
using EsecureModel.Exam;
using AppEsecure.Helper;

namespace AppEsecure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckListPage : ContentPage
    {
        public HttpClient _client;
        List<Test> t = new List<Test>();

        string lista = "";
        public CheckListPage()
        {

            InitializeComponent();
            // lst.ItemsSource = new List<string>() { };
        }
        /*
        public async Task Test()
        {
            lista = await DownloadPage("http://18.231.176.208/gemba/api/tests");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/planes");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/tests/2");
        }
        /*
        public static async Task<string> DownloadPage(string url)
        {
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }*/
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // await Test();
            // json
            var lala = await JsonHelper.GetStringFromJson("http://18.231.176.208/gemba/api/tests");
            var listaTest = JsonConvert.DeserializeObject<IList<Test>>(lala);
            lsta.ItemsSource = listaTest;
            var imgsource = "https://image.flaticon.com/icons/svg/1001/1001044.svg";
            /*
            var texts = "";
            foreach(var i in listaTest)
            {
                texts = texts + i.ToString() + "\n";
            }
            messageLabel.Text = texts;
            // var foo = GetAllFoos(lista);
            // messageLabel.Text = foo;
            */
            BindingContext = this;
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            var item = (Test) lsta.SelectedItem;
            messageLabela.Text = "OnItemSelected -> ID: " + item.TestID + " Nombre: " + item.Name;


        }

        /*
        public string GetAllFoos(string jsonList)
        {
            List<Test> newList = new List<Test>();
            var txt = "";
            var responseAsConcreteType = JsonConvert.DeserializeObject<IList<Test>>(jsonList);
            if (responseAsConcreteType != null)
            {
                foreach (var val in responseAsConcreteType)
                {
                    txt = txt + "CheckList ID: " + val.TestID + " -> " + val.Name + "\n";
                }
            }
            return txt;
        }*/
        void Button_SendResponse(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Id)
            {
                default:
                    break;

            }
        }
    }
}