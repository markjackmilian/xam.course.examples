using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xam.Zero.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xam.course.example1.Features.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : PopupPage, IXamZeroPopup
    {
        public DetailPage()
        {
            InitializeComponent();
        }
    }
}