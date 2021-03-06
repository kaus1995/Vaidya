﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Vaidya
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}
        public void Chat(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ChatPage());
        }
        public void Scan(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new CameraPage());
        }
        
    }
}