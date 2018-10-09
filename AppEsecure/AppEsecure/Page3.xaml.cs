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
using EsecureModel.Issues;
using System.Windows.Input;

namespace AppEsecure
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public ICommand NavigateCommand { private set; get; }
        public HttpClient _client;
        List<Test> t = new List<Test>();

        string lista = "";
        public Page3()
        {
            InitializeComponent();
            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });
        }
        /*
            lista = await DownloadPage("http://18.231.176.208/gemba/api/tests");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/planes");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/tests/2");
            // http://18.231.176.208/gemba/api/IssueItems
        */
        private async void Button_Clicked(object sender, EventArgs e)
        {
            // json
            var lala = await JsonHelper.GetStringFromJson("http://18.231.176.208/gemba/api/IssueItems");
            var listaPlanes = JsonConvert.DeserializeObject<IList<IssueItem>>(lala);
            lst.ItemsSource = listaPlanes;
            // var imgsource = "https://image.flaticon.com/icons/svg/1001/1001044.svg";
            BindingContext = this;
        }

        private void OnItemSelected(object sender, EventArgs e)
        {
            var item = (IssueItem) lst.SelectedItem;
            messageLabel.Text = "OnItemSelected -> ID: " + item.IssueItemID +" Descr.: " + item.Descripcion;
        }
        private async void Create_Issue(object sender, EventArgs e)
        {
            // Page page = (NavigationPage)Activator.CreateInstance( (NavigationPage) CreateIssue() );
            await Navigation.PushAsync(new CreateIssue());
        }
    }
}