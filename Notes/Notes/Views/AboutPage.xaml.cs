using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            var categories = new ObservableCollection<CategoryModel>() {
            new CategoryModel{CategoryName="Robins AFB",Values= {new ValueModel{ ValueName="Runway 15" }, new ValueModel { ValueName = "Runway 2" }, new ValueModel { ValueName = "Runway 3" } ,new ValueModel{ ValueName= "Runway 4" } } },
            new CategoryModel{CategoryName="Hill AFB",Values= {new ValueModel{ ValueName= "Runway 5" }, new ValueModel { ValueName = "Runway 4" }, new ValueModel { ValueName = "7" } } },
            new CategoryModel{CategoryName="Tinker AFB",Values= {new ValueModel{ ValueName= "Runway 4" }, new ValueModel { ValueName = "Runway 2" }, new ValueModel { ValueName = "7" } } },
            new CategoryModel{CategoryName="Shaw AFB",Values= {new ValueModel{ ValueName= "Runway 55" }, new ValueModel { ValueName = "Runway 5" }, new ValueModel { ValueName = "7" } } },
            new CategoryModel{CategoryName="Atlanta",Values= {new ValueModel{ ValueName= "Runway 3" }, new ValueModel { ValueName = "Runway 6" }, new ValueModel { ValueName = "7" } } }

        };

            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Categories = categories
            };

            BindingContext = categoryViewModel;

        }

        private void DiameterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            CategoryViewModel viewModel = BindingContext as CategoryViewModel;
            ValuePicker.ItemsSource = viewModel.Categories[((Picker)sender).SelectedIndex].Values;
        }
    }



}
