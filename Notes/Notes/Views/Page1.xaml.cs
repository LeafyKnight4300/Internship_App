using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Notes.Views
{
    public partial class Page1 : ContentPage
    {
        
       

        public Page1()
        {
            InitializeComponent();
        }
        async void OnDisplayAlertButtonClicked(object sender, EventArgs e)
        {
            bool start = await DisplayAlert("hello random person", "My name is William, and odds are im taller than you", "Gotcha", "Doubt it");
            if (start == false)
            {
              await DisplayAlert("Bruh","", null, "¯|_ (ツ)_|¯");     
            }

        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            // Launch the specified URL in the system browser.
            await Launcher.OpenAsync("https://m.twitch.tv/videos/1519067637");
        }


    }


      
        

}
