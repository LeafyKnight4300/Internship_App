using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class AboutPage : ContentPage
    {
        string address = "http://airnav.com/airport/";
        string Weather = "https://weather.com/weather/today/l/";
        public AboutPage()
        {

            InitializeComponent();
            var Local = new Dictionary<string, string>
        {  {"Hill", "KHIF"}, {"Robins", "KWRB"}, {"Tinker", "KTIK"}, {"Shaw", "KSSC"}, {"Atlanta", "KATL"}
        };

            foreach (string place in Local.Keys)
            {
                Location.Items.Add(place);
            }
            Runway.Items.Add("");

            HtmlWeb web = new HtmlWeb();
           HtmlDocument doc = web.Load(address);
            HtmlDocument weather = web.Load(Weather);


            Location.SelectedIndexChanged += (sender, args) =>
            {

                if (Location.SelectedIndex != -1)
                {
                    string spot = (string)Location.SelectedItem;
                    reset();
                    address += Local[spot];
                    doc = web.Load(address);

                    if (doc.DocumentNode.SelectNodes("/html/body/table[5]/tr/td[1]/h4") == null)
                    {
                        Runway.Title = "Website is down, try again later";
                        
                    }
                    else
                    {
                    populator();
                    location();
                    temp();
                    windSpeed();
                    }
                }
            };
            Runway.SelectedIndexChanged += (sender, args) =>
            {
                if (Runway.SelectedIndex != -1)
                {
                    runwayName();
                    runwayDimensions();
                    runwayElevation();
                }
            };

            void populator()
            {
                foreach (var item in doc.DocumentNode.SelectNodes("/html/body/table[5]/tr/td[1]/h4"))
                {
                    var split = item.InnerText;
                    split = split.Replace("Runway ", "");
                    string[] runways = split.Split('/');
                    Runway.Items.Add(runways[0]);
                    Runway.Items.Add(runways[1]);

                }
            }
            void reset()
            {
                foreach (KeyValuePair<string, string> kvp in Local)
                    address = address.Replace(kvp.Value, "");
                Runway.Items.Clear();
                //place.Text = "";
                //WindSpeed.Text = "";
                //temperature.Text = "";
                rname.Text = "";
                RunwayDimension.Text = "";
                RunwayElevation.Text = "";
            }
            void location()
            {
                string test = doc.DocumentNode.SelectNodes("/html/body/table[3]/tr/td[2]/font/text()")[0].InnerText;
                place.Text = test;
            }
            void temp()
            {
                string x = doc.DocumentNode.SelectNodes("/html/body/table[5]/tr/td[1]/table[1]/tr[7]/td[2]")[0].InnerText;
                Weather += x;
                Console.WriteLine(Weather);
                weather = web.Load(Weather);
                string currentTemp = weather.DocumentNode.SelectNodes("/html/body/div[1]/main/div[2]/main/div[1]/div/section/div/div[2]/div[1]/div[1]/span")[0].InnerText;
                Weather = "https://weather.com/weather/today/l/";
                temperature.Text = currentTemp;
            }
            void windSpeed()
            {
                string x = doc.DocumentNode.SelectNodes("/html/body/table[5]/tr/td[1]/table[1]/tr[7]/td[2]")[0].InnerText;
                Weather += x;
                weather = web.Load(Weather);
                string wind = weather.DocumentNode.SelectNodes("//*[@id='todayDetails']/section/div[2]/div[2]/div[2]/span")[0].InnerText;
                wind = wind.Replace("Wind Direction", "");
                Weather = "https://weather.com/weather/today/l/";
                WindSpeed.Text = wind;
            }
            void runwayName()
            {
                string x = Runway.SelectedItem.ToString();
                rname.Text = "Runway " + x;
            }
            void runwayDimensions()
            {
                int count = Runway.SelectedIndex;
                count /= 2;
                count += 7;
                if (Location.SelectedIndex == 0)
                    count -= 1;
                var test = doc.DocumentNode.SelectNodes("/html/body/table[5]/tr/td[1]/table[" + count as string + "]/tr[1]/td[2]")[0].InnerText;
                RunwayDimension.Text = test;
                Info.setRunwayData(test);
                
                
            }
            void runwayElevation()
            {
                int number = 0;
                int spot = Runway.SelectedIndex;
                int count = Runway.SelectedIndex;
                count /= 2;
                count += 7;
                spot %= 2;
                if (spot == 0)
                {
                    number = 2;
                }
                else if (spot == 1)
                {
                    number = 4;
                }
                if (Location.SelectedIndex == 0)
                    count -= 1;
                var test = doc.DocumentNode.SelectNodes("/html/body/table[5]/tr/td[1]/table[" + count as string + "]/tr[8]/td[" + number + "]")[0].InnerText;
                RunwayElevation.Text = test;

            }
        } 
    }
}
