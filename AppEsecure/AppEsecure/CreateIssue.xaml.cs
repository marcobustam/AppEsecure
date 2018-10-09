using AppEsecure.Helper;
using EsecureModel.Issues;
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
	public partial class CreateIssue : ContentPage
	{
        public string urlToCreate = "";
		public CreateIssue ()
		{
			InitializeComponent ();
		}
        public void OnPostIssue(object sender, EventArgs e)
        {
            var newIssue = new IssueItem() {
                Descripcion ="App Esecure " + issueDesc.Text,
                IssueListId = 1
            };
            var json = JsonConvert.SerializeObject(newIssue);
            var x = JsonHelper.PostFromJson("http://18.231.176.208/gemba/api/IssueItems/", json);
            
        }
    }
}