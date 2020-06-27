using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCore.Session7.Common
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        //[ConcurrencyCheck]
        public string LastName { get; set; }
        public Address Home { get; set; }
        public DateTime BirthDate { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Year { get; private set; }
        public BankAcount BankAcount { get; set; }
        [Timestamp]
        public byte[] Token { get; set; }
    }
    public class BankAcount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public Person Person { get; set; }
    }
    public class Address
    {
        public string AddressLine { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class Teacher:Person
    {
        public string Code { get; set; }
    }
    public static class DbFunctions
    {
       public static int MyFunction()
        {
            throw new NotImplementedException();
        }
    }
    class DateTimeValueGenerator : ValueGenerator<DateTime>
    {
        public override bool GeneratesTemporaryValues => throw new NotImplementedException();

        public override DateTime Next( EntityEntry entry)
        {
            return DateTime.Now.AddYears(-10);
        }
    }
    public class PersonContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<BankAcount> BankAccount { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=PersonDb; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("People");
            modelBuilder.Entity<BankAcount>().ToTable("People");
            modelBuilder.Entity<Person>().HasOne(c => c.BankAcount).WithOne(c => c.Person).HasForeignKey<Person>(c => c.Id);
            modelBuilder.Entity<Person>().OwnsOne(c => c.Home);
            modelBuilder.HasDbFunction(() => DbFunctions.MyFunction());
            modelBuilder.Entity<Person>().Property(c => c.Year).HasComputedColumnSql("DatePart(yyyy,[DateofBirth])");
            modelBuilder.Entity<Person>().Property(c => c.BirthDate).HasValueGenerator(typeof(DateTimeValueGenerator));
            modelBuilder.Entity<Person>().Property(c => c.FirstName).IsConcurrencyToken();
            modelBuilder.Entity<Person>().Property(c => c.Token).IsRowVersion();
            //modelBuilder.Entity<Person>().Property(c => c.Year).ValueGeneratedOnAddOrUpdate();
            //modelBuilder.HasSequence<int>("TestIntSeq", c =>
            //{
            //    c.
            //});            

        }

    }
}
