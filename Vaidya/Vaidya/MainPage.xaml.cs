using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Vaidya
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        public async Task Register(object sender, EventArgs e)
        {
            //DisplayAlert("Welcome to Vaidya!", "Go ahead and log in, Press OK to continue!", "OK");

            Contact log = new Contact();
            log.Email = email.Text;
            log.Password = pswrd.Text;
            log.FirstName = fName.Text;
            log.LastName = lName.Text;
            log.DOB = date.Date;
            log.Address = addr.Text;
            log.PhoneNumber = Convert.ToInt32(phone.Text);
            HttpClient client = new HttpClient();
            string url = "http://vaidyawebapi20180616064640.azurewebsites.net/api/Xamarin_reg";
            var uri = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;
            var json = JsonConvert.SerializeObject(log);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            response = await client.PostAsync(uri, content);
            if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var errorMessage1 = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                await DisplayAlert("Update!", errorMessage1, "OK");
            }
            else
            {
                var errorMessage1 = response.Content.ReadAsStringAsync().Result.Replace("\\", "").Trim(new char[1] { '"' });
                await DisplayAlert("Error!", errorMessage1, "OK");
            }
        }

        public void Login(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}
