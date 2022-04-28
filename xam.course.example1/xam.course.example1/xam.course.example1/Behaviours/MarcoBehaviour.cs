using mjm.nethelpers.Extensions;
using Xamarin.Forms;

namespace xam.course.example1.Behaviours
{
    public class MarcoBehaviour : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += BindableOnTextChanged;
        }

        private void BindableOnTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender.To<Entry>();
            entry.TextColor = entry.Text.ToLower().StartsWith("marc") ? 
                Color.Gold : Color.Red;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= this.BindableOnTextChanged;
        }
    }
}