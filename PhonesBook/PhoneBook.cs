using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace PhonesBook;

public class PhoneBook
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public string PhoneNumber { get; set; }
}

public class PhoneBookDbContext : DbContext
{
    public DbSet<PhoneBook> Phones => Set<PhoneBook>();

    
    public PhoneBookDbContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=phonenumbers.db");
}