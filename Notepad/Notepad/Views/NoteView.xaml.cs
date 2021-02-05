using Notepad.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteView : ContentPage
    {
        //Fields
        private Note note;

        public NoteView()
        {
            InitializeComponent();
            note = new Note();
            BindingContext = note;
            saveButton.IsVisible = false;
            noteTitle.MaxLength = 255;
        }

        public NoteView(Note note)
        {
            InitializeComponent();
            this.note = note;
            BindingContext = this.note;
            saveButton.IsVisible = false;
            noteTitle.MaxLength = 255;
            
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            saveButton.IsEnabled = false;
            await Storage.GetInstance().WriteNote(note);
            await Navigation.PopModalAsync(true);
            saveButton.IsEnabled = true;
        }

        private void noteTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                saveButton.IsVisible = true;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(noteTextContent.Text))
                {
                    saveButton.IsVisible = true;
                }
                else
                {
                    saveButton.IsVisible = false;
                }
            }
        }
    }
}