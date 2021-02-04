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
    public partial class CustomSearchBar : Frame
    {
        public CustomSearchBar()
        {
            InitializeComponent();
        }
    }
}