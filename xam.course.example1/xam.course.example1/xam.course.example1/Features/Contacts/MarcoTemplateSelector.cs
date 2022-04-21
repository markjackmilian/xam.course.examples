using mjm.nethelpers.Extensions;
using xam.course.core.Models;
using Xamarin.Forms;

namespace xam.course.example1.Features.Contacts
{
    public class MarcoTemplateSelector : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var model = item.To<ContactModel>();
            return model.Name.ToLower().StartsWith("marco") ? this.MarcoTemplate : this.OtherTemplate;
        }

        public DataTemplate MarcoTemplate { get; set; }
        public DataTemplate OtherTemplate { get; set; }
    }
}