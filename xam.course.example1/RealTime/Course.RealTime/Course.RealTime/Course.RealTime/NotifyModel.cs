using System.ComponentModel;
using System.Runtime.CompilerServices;
using Course.RealTime.Annotations;

namespace Course.RealTime
{
    public class NotifyModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}