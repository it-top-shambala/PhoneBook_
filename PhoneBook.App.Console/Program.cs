using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBook.DbLib;

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json");
var config = builder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var db = new PhoneBookContext(connectionString);
/*var person = new Person()
{
    LastName = "Starinin",
    FirstName = "Andrey"
};

var phone1 = new Phone()
{
    Type = PhoneType.Mobile,
    Number = "+79042144491",
    Person = person
};
var phone2 = new Phone()
{
    Type = PhoneType.Home,
    Number = "+7 473 257-57-55",
    Person = person
};

db.Phones.Add(phone1);
db.Phones.Add(phone2);

db.Persons.Add(person);
db.SaveChanges();*/

var persons = db.Persons.Include(person => person.Phones).ToList();
foreach (var person in persons)
{
    Console.WriteLine($"{person.LastName} {person.FirstName}:");
    var phones = person.Phones.ToList();
    foreach (var phone in phones)
    {
        Console.WriteLine($"\t\t{phone.Type.ToString()} {phone.Number}");
    }
}