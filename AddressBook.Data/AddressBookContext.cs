using AddressBook.DTO;
using System.Data.Entity;

namespace AddressBook.Data
{

    public class AddressBookContext : DbContext
    {

        public AddressBookContext() : base("AddressBookConnection")
        {
            Database.SetInitializer(new AddressBookInitializer());
        }
            public DbSet<AddressBookDTO> AddressBook { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if(modelBuilder!=null)
            modelBuilder.Entity<AddressBookDTO>().ToTable("AddressBook");
        }
    }

}
