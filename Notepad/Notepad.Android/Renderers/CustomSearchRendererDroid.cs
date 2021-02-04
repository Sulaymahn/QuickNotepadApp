using Android.Content;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Notepad.Droid.Renderers;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomSearchRendererDroid))]
namespace Notepad.Droid.Renderers
{
    class CustomSearchRendererDroid : EntryRenderer
    {
        public CustomSearchRendererDroid(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}