using System.Net.Http.Headers;
using System.Net.Http.Json;
using Newtonsoft.Json;
using CommonContracts;

namespace ServiceAgent.Agents
{
    public class AccountServiceAgent
    {
        internal static HttpClient httpClientInstance;
        internal static string connectionString = "";
        static Uri baseUri = new Uri("https://localhost:7058/api/user");
        //public static async void DBConnection_Start()
        static AccountServiceAgent()
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
    }
}
