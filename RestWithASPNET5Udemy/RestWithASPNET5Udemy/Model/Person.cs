using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5Udemy.Model
{
    [Table("person")]
    public class Person
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("first_name")]
        public string FirstName { get; set; }
        
        [Column("last_name")]
        public string LastName { get; set; }
        
        [Column("address")]
        public string AddressName { get; set; }
        
        [Column("gender")]
        public string GenderName { get; set; }
    }
}
