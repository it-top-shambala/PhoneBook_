using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Model;

public enum PhoneType
{
    Unknown, Mobile, Home
}

[Table("table_phones")]
[Index(nameof(Number), IsUnique = true, Name = "phone_number_index")]
public record Phone
{
    [Column("id")]
    [Required]
    public int Id { get; set; }
    
    [Column("phone_type")]
    [Required]
    public PhoneType Type { get; set; }
    
    [Column("number")]
    [Required]
    public string Number { get; set; }
    
    [Column("person_id")]
    [Required]
    public int PersonId { get; set; }
    [ForeignKey(nameof(PersonId))]
    public Person Person { get; set; }
}