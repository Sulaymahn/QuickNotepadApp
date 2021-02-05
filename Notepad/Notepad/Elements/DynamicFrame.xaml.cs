using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notepad.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicFrame : Frame
    {
        public DynamicFrame(Note note)
        {
            InitializeComponent();

            switch (frameType(note))
            {
                case FrameType.Titled:
                    Content = new StackLayout
                    {

                    };
                    break;
                case FrameType.Detailed:
                    break;
                case FrameType.Description:
                    
                    break;
            }
        }

        private FrameType frameType(Note note)
        {
            if (string.IsNullOrEmpty(note.Title))
            {

            }
            return FrameType.Description;
        }
    }

    public enum FrameType
    {
        Titled,
        Detailed,
        Description
    }
}