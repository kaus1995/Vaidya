using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vaidya
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChatPage : ContentPage
	{
		public ChatPage ()
		{
			InitializeComponent ();
        }
        protected override void OnAppearing()
        {
            DisplayAlert("Welcome to Vaidya!", "Say \"Hii\" to start the conversation.Press OK to continue.", "OK");
        }
    }
}