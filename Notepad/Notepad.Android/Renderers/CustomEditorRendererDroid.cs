using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Editor), typeof(Notepad.Droid.Renderers.CustomEditorRendererDroid))]
namespace Notepad.Droid.Renderers
{
    public class CustomEditorRendererDroid : EditorRenderer
    {
        public CustomEditorRendererDroid(Context context) :base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}