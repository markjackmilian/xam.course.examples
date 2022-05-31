using System.Collections.ObjectModel;
using System.Windows.Input;
using Xam.Zero.ViewModels;
using Xam.Zero.ZCommand;
using Xamarin.Forms.Maps;

namespace xam.course.example1.Features.CourseMap
{
    public class CourseMapPageViewModel : ZeroBaseModel
    {
        public ICommand CloseCommand { get;}

        public ICommand MapCommand { get; set; }

        public ObservableCollection<Location> Locations { get; } = new ObservableCollection<Location>();
      

        public CourseMapPageViewModel()
        {
            this.CloseCommand = ZeroCommand.On(this)
                .WithExecute((o, context) => this.PopModal())
                .Build();

            this.MapCommand = ZeroCommand<Position>.On(this)
                .WithExecute((o, context) =>
                {
                    var t = 5;
                })
                .Build();
        }

        public void AddLocation(Position ePosition)
        {
            this.Locations.Add(new Location
            {
                Position = ePosition,
                Title = "Eccolo"
            });
        }
    }
}