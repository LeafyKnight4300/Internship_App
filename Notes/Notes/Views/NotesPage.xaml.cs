using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
       
        public NotesPage()
        {
            InitializeComponent();
            double basew = 400000;
            double maxW = 685000;
            double slots = 3;

            double slot1 = 0;
            double slot2 = 0;
            double slot3 = 0;
            double slot4 = 0;
            double slot5 = 0;
            double total = 0;
            


            var cargo = new Dictionary<string, int>
        {  {"Humvee", 7700 }, {"M1 Tank", 120000}, {"UH-60 Blackhawk", 13650}, {"Stryker ICV", 32940}, {"CV90", 54000}
        };
            List<Label> numbers = new List<Label>() { label1, label2, label3, label4, label5 };
            List<Picker> pickerList = new List<Picker>() { picker1, picker2, picker3, picker4, picker5 };
            foreach (Picker picker in pickerList)
            {
                foreach (string load in cargo.Keys)
                {
                    picker.Items.Add(load);
                }
                picker.Items.Add("");
                
            }
            foreach (Label label in numbers)
            {
                label.IsVisible = false;
            }
            foreach (Picker picker in pickerList)
            {
                picker.IsVisible = false;
            }

            int i = 0;
            while (i < slots)
            {
                numbers[i].IsVisible = true;
                pickerList[i].IsVisible = true;
                i++;
            }



            foreach (Picker picker in pickerList)
            {
                picker.SelectedIndexChanged += (sender, args) =>
                {
                    string load = (string)picker.SelectedItem;
                    int x = cargo[load];
                    if (picker == picker1)
                    {
                        string item = (string)picker.SelectedItem;
                        slot1 = cargo[item];
                    }
                    else if (picker == picker2)
                    {
                        string item = (string)picker.SelectedItem;
                        slot2 = cargo[item];
                    }
                    else if (picker == picker3)
                    {
                        string item = (string)picker.SelectedItem;
                        slot3 = cargo[item];
                    }
                    else if (picker == picker4)
                    {
                        string item = (string)picker.SelectedItem;
                        slot4 = cargo[item];
                    }
                    else if(picker == picker5)
                    {
                        string item = (string)picker.SelectedItem;
                        slot5 = cargo[item];
                    }
                    total =  basew + slot1 + slot2 + slot3 + slot4 + slot5;
                    string tempTotal = total.ToString();
                    WEIGHT.Text = tempTotal;

                    double ballance = 0;
                    if (slots == 2)
                    {
                        ballance = (slot1 - slot2) / basew;
                    }
                    else if (slots == 3)
                    {
                        ballance = (slot1 - slot3) / basew;
                    }
                    else if (slots == 4)
                    {
                        ballance = (((slot1 * 2) + slot2) - (slot3 + (slot4 * 2))) / basew;
                    }
                    else if (slots == 5)
                    {
                        ballance = (((slot1 * 2) + slot2) - (slot4 + (slot5 * 2))) / basew;
                    }
                    
                    if (ballance <= .1 && ballance >= -.1)
                    {
                        WEIGHT1.Text = "Aircraft is ballanced";
                        WEIGHT1.BackgroundColor = Color.Green;
                    }
                    if (total <= maxW)
                    {
                        WEIGHT2.Text = "Aircraft is safe to take off";
                        WEIGHT2.BackgroundColor = Color.Green;
                    }
                    if (total > maxW)
                    {
                        WEIGHT2.Text = "Aircraft is overweight";
                        WEIGHT2.BackgroundColor = Color.Red;
                    }
                    if (ballance > .1 || ballance < -.1)
                    {
                        WEIGHT1.Text = "Aircraft is NOT ballanced";
                        WEIGHT2.Text = "Aircraft is NOT safe to take off";
                        WEIGHT1.BackgroundColor = Color.Red;
                        WEIGHT2.BackgroundColor = Color.Red;
                    }
                };
            }



        }


    }  
            
}