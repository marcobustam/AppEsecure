using AppEsecure.Helper;
using EsecureModel.Exam;
using Newtonsoft.Json;
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
    public partial class Page4 : ContentPage
    {
        public Page4()
        {
            InitializeComponent();
        }
        public Page4(int id)
        {
            InitializeComponent();
            var lala = JsonHelper.GetStringFromJson("http://18.231.176.208/gemba/api/Questions/1");
            IList<Question> listaPlanes = JsonConvert.DeserializeObject<IList<Question>>(lala);
            lst.ItemsSource = listaPlanes;
            // var imgsource = "https://image.flaticon.com/icons/svg/1001/1001044.svg";
            BindingContext = this;
        }
    }
}