using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mjm.nethelpers.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace xam.course.example1.Features.CourseMap
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseMapPage : ContentPage
    {
        public CourseMapPage()
        {
            InitializeComponent();
            
        }

        private async void Map_OnMapClicked(object sender, MapClickedEventArgs e)
        {
            this.BindingContext.To<CourseMapPageViewModel>().AddLocation(e.Position);
            
            // var pin = new Pin
            // {
            //     Position = e.Position,
            //     Label = "QUI",
            // };
            //
            // this.MyMap.Pins.Add(pin);
        }
    }
}