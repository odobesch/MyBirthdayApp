using SQLite;

namespace MyBirthdayApp.Models
{
    [Table("People")]
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), NotNull]
        public string FirstName { get; set; }

        [MaxLength(250), NotNull]
        public string LastName { get; set; }

        public string Picture { get; set; }

        public DateTime Dob { get; set; }

        public int Age { get ; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
