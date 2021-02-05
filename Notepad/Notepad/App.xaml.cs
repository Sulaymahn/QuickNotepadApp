using Notepad.Views;
using Xamarin.Forms;

namespace Notepad
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new Main();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
