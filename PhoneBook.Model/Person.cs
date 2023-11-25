using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhoneBook.Model;

//public record Person(int Id, string LastName, string? FirstName, List<Phone> Phones);
[Table("table_persons")]
public record Person
{
    [Column("id")]
    [Required]
    public int Id { get; set; }
    
    [Column("last_name")]
    [Required]
    public string LastName { get; set; }
    
    [Column("first_name")]
    public string? FirstName { get; set; }

    public IEnumerable<Phone> Phones { get; set; } = new List<Phone>();
}