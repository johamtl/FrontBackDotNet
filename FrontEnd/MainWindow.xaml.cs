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
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Json;
using studyGroupProject1.classes;
using System.Reflection;


namespace studyGroupProject1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal static HttpClient httpClientInstance;
        internal static string connectionString = "";
        Uri baseUri = new Uri("https://localhost:7058/api/dog");

        public MainWindow()
        {
            InitializeComponent();
            DBConnection_Start();
        }

        private void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text) && !lstNames.Items.Contains(txtName.Text))
            {
                lstNames.Items.Add(txtName.Text);
                txtName.Clear();
            }
        }
        protected async void DBConnection_Start()
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
        protected async void Get()
        {
            var builder = new UriBuilder(baseUri);
            builder.Query = "1=1";
            var url = builder.ToString();
            string results = await httpClientInstance.GetStringAsync(url);

            List<Dog> dog = JsonConvert.DeserializeObject<List<Dog>>(results);

            foreach (var a in dog)
            {
                lstNames.Items.Add(a.Name);
            }
        }

        protected async void Post()
        {
            var record = new
            {
                Name = "Foo",
                Id=4
            };

            JsonContent content = JsonContent.Create(record);
            HttpResponseMessage result = await httpClientInstance.PostAsync(baseUri, content);
            MessageBox.Show(result.ToString());
        }

        private void ButtonShowCurrentUsers_Click(object sender, RoutedEventArgs e)
        {
            Get();
        }
    }
}
