using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {

        string airplane = (string)Info.getActivePlane();
        int runDimensions = 0;
        int slots;
        double basew = 0;
        double maxW = 0;
        int takeoff;
        int landing;

        double slot1 = 0;
        double slot2 = 0;
        double slot3 = 0;
        double slot4 = 0;
        double slot5 = 0;
        double total = 0;

        public NotesPage()
        {
            InitializeComponent();
            OnAppearing();

            List<Label> numbers = new List<Label>() { label1, label2, label3, label4, label5 };
            List<Picker> pickerList = new List<Picker>() { picker1, picker2, picker3, picker4, picker5 };

            var cargo = new Dictionary<string, int>
        {  {"Humvee", 7700 }, {"M1 Tank", 120000}, {"UH-60 Blackhawk", 13650}, {"Stryker ICV", 32940}, {"CV90", 54000}, {"empty", 0}
        };

            foreach (Picker picker in pickerList)
            {
                foreach (string load in cargo.Keys)
                {
                    picker.Items.Add(load);
                }
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
                    else if (picker == picker5)
                    {
                        string item = (string)picker.SelectedItem;
                        slot5 = cargo[item];
                    }
                    List<double> ints = new List<double>() { slot1, slot2, slot3, slot4, slot5 };
                    int loop = 0;
                    total = basew;
                    while (loop < slots)
                    {
                        total = total + ints[loop];
                        loop++;
                    }


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
                        WEIGHT1.Text = "Aircraft is overweight";
                        WEIGHT1.BackgroundColor = Color.Red;
                        WEIGHT2.Text = "Aircraft is NOT safe to take off";
                        WEIGHT2.BackgroundColor = Color.Red;

                    }
                    if (ballance > .1 || ballance < -.1)
                    {
                        WEIGHT1.Text = "Aircraft is NOT ballanced";
                        WEIGHT2.Text = "Aircraft is NOT safe to take off";
                        WEIGHT1.BackgroundColor = Color.Red;
                        WEIGHT2.BackgroundColor = Color.Red;
                    }

                    if (runDimensions == 0)
                    {
                        WEIGHT2.Text = "Select a Runway";
                        WEIGHT2.BackgroundColor = Color.DarkGray;
                    }

                };
            }
        }
        protected override void OnAppearing()
            {List<Label> numbers = new List<Label>() { label1, label2, label3, label4, label5 };
            List<Picker> pickerList = new List<Picker>() { picker1, picker2, picker3, picker4, picker5 };

            if (Info.getRunwayData() != null)
            {
                string runwayData = (string)Info.getRunwayData();
                string[] strings = runwayData.Split(' ');
                runDimensions = Int32.Parse(strings[0]);
            }
            
            foreach (Picker picker in pickerList)
            {
                picker.SelectedIndex = -1;
            }

            airplane = (string)Info.getActivePlane();
            if (airplane == "C-5") { slots = 5; basew = 400000; maxW = 685000; takeoff = 8300; landing = 4900; }
            else if (airplane == "C-17") { slots = 4; basew = 282400; maxW = 453300; takeoff = 8200; landing = 3500; }
            else if (airplane == "C-130") { slots = 3; basew = 74540; maxW = 119840; takeoff = 3586; landing = 2500; }
            else if (airplane == "F-15") { slots = 2; basew = 45000; maxW = 68000; takeoff = 1000; landing = 1650; }
            else if (airplane == "Boeing 747") { slots = 5; basew = 404600; maxW = 653200; takeoff = 10450; landing= 6920; }

            if (basew == 0)
            {
                WEIGHT.Text = "Select an Aircraft";
                WEIGHT1.Text = "Select an Aircraft";
                WEIGHT2.Text = "Select an Aircraft";
            }
            else if (maxW > total)
            {
                WEIGHT.Text = basew.ToString();
                WEIGHT1.Text = "Aircraft is ballanced";
                WEIGHT1.BackgroundColor = Color.Green;
                WEIGHT2.Text = "Aircraft is safe to take off";
                WEIGHT2.BackgroundColor = Color.Green;
            }

            foreach (Label label in numbers)
            {
                label.IsVisible = false;
            }
            foreach (Picker picker in pickerList)
            {
                picker.IsVisible = false;
            }
            
            if (runDimensions == 0)
            {
                WEIGHT2.Text = "Select a Runway";
                WEIGHT2.BackgroundColor = Color.DarkGray;
            }
            else if (runDimensions < landing || runDimensions < takeoff)
            {
                WEIGHT2.Text = "Runway is too short to take off";
                WEIGHT2.BackgroundColor = Color.Red;
            }
            
                int i = 0;
            while (i < slots)
            {
                numbers[i].IsVisible = true;
                pickerList[i].IsVisible = true;
                i++;
            }
            foreach (Label label in numbers)
            {
                label.IsVisible = false;
            }
            foreach (Picker picker in pickerList)
            {
                picker.IsVisible = false;
            }
            int t = 0;
            while (t < slots)
            {
                numbers[t].IsVisible = true;
                pickerList[t].IsVisible = true;
                t++;
            }
            List<double> ints = new List<double>() { slot1, slot2, slot3, slot4, slot5 };
            int loop = 0;
            total = basew;
            while (loop < slots)
            {
                total = total + ints[loop];
                loop++;
            }
            string tempTotal = total.ToString();
            WEIGHT.Text = tempTotal;
            

        }

    }
}
               
            
