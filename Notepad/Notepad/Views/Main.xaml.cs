
using Notepad.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;

namespace Notepad.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {

        public Main()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            collectionView.ItemsSource = Storage.GetInstance().GetCollection();
            base.OnAppearing();
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (collectionView.SelectedItem != null)
            {
                var note = collectionView.SelectedItem as Note;
                await Navigation.PushModalAsync(new NoteView(note), true);
            }

            collectionView.SelectedItem = null;
        }

        private async void New_Clicked(object sender, EventArgs e)
        {
            newButton.IsEnabled = false;
            await newButton.RotateTo(90, 250, Easing.SinIn);
            await Navigation.PushModalAsync(new NoteView(), true);
            newButton.IsEnabled = true;
            newButton.Rotation = 0;
        }

        private void DeleteItem_Invoked(object sender, EventArgs e)
        {
            var swipeItem = sender as SwipeItem;
            var note = swipeItem.CommandParameter as Note;
            Storage.GetInstance().DeleteNote(note);
            collectionView.ItemsSource = Storage.GetInstance().GetCollection();
        }

        private void CustomSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                collectionView.ItemsSource =
                    from note in Storage.GetInstance().GetCollection()
                    where Resemble(note.Title, e.NewTextValue)
                    select note;
            }
            else
            {
                collectionView.ItemsSource = Storage.GetInstance().GetCollection();
            }
        }

        private bool Resemble(string objA, string objB)
        {
            objA = objA.ToLower();
            objB = objB.ToLower();
            int len = IsShorter(objA, objB);
            for(int i = 0; i < len; i++)
                {
                    if(objA[i] != objB[i])
                    {
                        return false;
                    }
                }


            return true;
        }

        private int IsShorter(string a, string b)
        {
            if(a.Length > b.Length)
            {
                return b.Length;
            }
            else
            {
                return a.Length;
            }
        }
    }
}