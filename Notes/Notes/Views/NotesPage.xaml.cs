using System;
using System.IO;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes.txt");

        public NotesPage()
        {
            InitializeComponent();

            // Read the file.
            
        }

        void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Save the file.
            
        }

        void OnDeleteButtonClicked(object sender, EventArgs e)
        {
           
        }
    }
}