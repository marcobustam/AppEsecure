using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using Newtonsoft.Json;
using EsecureModel.Exam;
using System.Net;
using System.Security;
using Android.Hardware.Usb;
using System.Text;

namespace AppEsecure.Helper
{
    class JsonHelper
    {
        public static async Task<string> PostFromJson(string url, string json)
        {
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                            {
                                new KeyValuePair<string, string>("somekey", "1"),
                            });
                using (var r = await client.PostAsync(new Uri(url), stringContent) )
                {
                    return "";
                }
            }
        }
        /*
        public static async Task<IList<Object>> GetListFromJson ( string url, Type t)
        {
            var type = t.GetType();
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    string result = await r.Content.ReadAsStringAsync();
                    var responseAsConcreteType = JsonConvert.DeserializeObject<IList<type>> (result);
                    return (IList<type>) responseAsConcreteType;
                }
            }
        }*/
        public static async Task<string> GetStringFromJson(string url)
        {
            //var type = t.GetType();
            using (var client = new HttpClient())
            {
                using (var r = await client.GetAsync(new Uri(url)))
                {
                    /*
                     * HttpContent content = new StringContent(package, Encoding.UTF8, WebConstants.ContentTypeJson);
                    content.Headers.Add(_header, token);

                    var resp = await client.PostAsync(url, content, ct);

                    if (r.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new SecurityException(UsbConstants.ServiceSecWarning, new Exception(r.Content.ToString()));
                    } */
                    /*
                     async void PostRequest(string URL)
                    {
                        var formContent = new FormUrlEncodedContent(new[]
                            {
                                new KeyValuePair<string, string>("somekey", "1"), 
                            });

                        var myHttpClient = new HttpClient();
                        var response = await myHttpClient.PostAsync(URL, formContent);

                        var json = await response.Content.ReadAsStringAsync();
                        Events result = JsonConvert.DeserializeObject<Events>(json);
                    }
                     */
                    string result = await r.Content.ReadAsStringAsync();
                    return result;
                }
            }
        }
        /*
        public async Task Test()
        {
            lista = await DownloadPage("http://18.231.176.208/gemba/api/tests");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/planes");
            // lista = await DownloadPage("http://18.231.176.208/gemba/api/tests/2");
        }

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
        }
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
    }
}
