using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;
using studyGroupProject1.classes;
using System.Reflection;

namespace studyGroupProject1.service
{
    internal class DogService
    {

        internal static HttpClient httpClientInstance;
        internal static string connectionString = "";
        static Uri baseUri = new Uri("https://localhost:7058/api/dog");
        //public static async void DBConnection_Start()
        static DogService()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);

            httpClientInstance = new HttpClient();
            httpClientInstance.BaseAddress = baseUri;
            httpClientInstance.DefaultRequestHeaders.Clear();
            httpClientInstance.DefaultRequestHeaders.ConnectionClose = false;
            httpClientInstance.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //ServicePointManager.FindServicePoint(baseUri).ConnectionLeaseTimeout = 60 * 1000;
        }
        public static async Task<List<Dog>> GetAllDog()
        {
            var builder = new UriBuilder(baseUri);
            builder.Query = "1=1";
            var url = builder.ToString();
            string results = await httpClientInstance.GetStringAsync(url);

            List<Dog> dog = JsonConvert.DeserializeObject<List<Dog>>(results);

            return dog;
        }
        public static async Task<Boolean> Post(Dog dog)
        {
            JsonContent content = JsonContent.Create(dog);
            HttpResponseMessage result = await httpClientInstance.PostAsync(baseUri, content);
            MessageBox.Show(result.ToString());
            return true;
        }
    }
}
