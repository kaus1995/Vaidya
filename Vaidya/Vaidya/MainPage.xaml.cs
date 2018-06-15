using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Register(object sender, EventArgs e)
        {
            DisplayAlert("Welcome to Vaidya!", "Go ahead and log in, Press OK to continue!","OK");
        }
        public void Login(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }
	}
}
