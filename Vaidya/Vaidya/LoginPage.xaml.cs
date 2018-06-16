using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vaidya
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        public async Task UserLogin(object sender, EventArgs e)
        {

            //Contact log = new Contact();
            //log.Email = email.Text;
            //log.Password = pswrd.Text;

            //HttpClient client = new HttpClient();
            //var uri = new Uri(string.Format("http://xamarinlogin.azurewebsites.net/api/Login?username=" + txtusername.Text + "&password=" + txtPassword.Text));
            //HttpResponseMessage response; ;
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //response = await client.GetAsync(uri);



            Contact log = new Contact();
            log.Email = email.Text;
            log.Password = Password.Text;
            HttpClient client = new HttpClient();
            string url = "http://vaidyawebapi20180616064640.azurewebsites.net/api/Xamarin_login";
            var uri = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(log);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri, content);

            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var errorMessage1 = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                //await DisplayAlert("Update!", errorMessage1, "OK");
                await Navigation.PushModalAsync(new MenuPage());
            }
            else
            {
                var errorMessage1 = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                await DisplayAlert("Error!", errorMessage1, "OK");
            }


        }
    }
}