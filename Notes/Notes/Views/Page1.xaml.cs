using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.Generic;

namespace Notes.Views
{
    public partial class Page1 : ContentPage
    {
       
        public Page1()
        {
            InitializeComponent();
            var page = new NotesPage();
            var aircraft = new Dictionary<string, int>
        {  {"C-5", 5}, {"C-17", 4}, {"C-130", 3}, {"F-15", 2}, {"Boeing 747", 5}
        };

            foreach (string place in aircraft.Keys)
            {
                picker.Items.Add(place);
            }

            picker.SelectedIndexChanged += (sender, args) =>
            {
                
                var x = picker.SelectedItem;
                int pickercount = aircraft[x as string];
                Console.WriteLine(pickercount);
                int i = 0;
                while ((pickercount - 1) > i)
                {
                    
                    
                    
                }
            };

        

    }


      
        

}}
