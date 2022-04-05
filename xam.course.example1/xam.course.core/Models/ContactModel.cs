using SQLite;

namespace xam.course.core.Models
{
    public class ContactModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Avatar { get; set; }

        public bool FromContacts { get; set; }
    }
}