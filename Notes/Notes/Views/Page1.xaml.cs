using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace Notes.Views
{
    public partial class Page1 : ContentPage
    {

        public int Pickercount { get; set; }

        public Page1()
        {
            InitializeComponent();
            
            var aircraft = new Dictionary<string, int>
        {  {"C-5", 5}, {"C-17", 4}, {"C-130", 3}, {"F-15", 2}, {"Boeing 747", 5}
        };

            foreach (string place in aircraft.Keys)
                {
                AircraftSelect.Items.Add(place);
                }


            AircraftSelect.SelectedIndexChanged += (sender, args) =>
            {
               
                var x = AircraftSelect.SelectedItem;
                
                Info.setActivePlane(x as string);
            };
        }
        

    }
}

