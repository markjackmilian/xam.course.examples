using Xamarin.Forms;

namespace xam.course.example1.Views
{
    public class MarcoEntry  : Entry
    {
        public MarcoEntry()
        {
            this.TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}