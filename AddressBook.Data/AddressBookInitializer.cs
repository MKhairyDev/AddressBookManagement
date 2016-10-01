using AddressBook.DTO;
using System.Collections.Generic;
using System.Data.Entity;

namespace AddressBook.Data
{
    public  class AddressBookInitializer: DropCreateDatabaseIfModelChanges<AddressBookContext>
    {
        protected override void Seed(AddressBookContext context)
        {
            if (context != null)
            {
                IList<AddressBookDTO> defaultStandards = new List<AddressBookDTO>();

                defaultStandards.Add(new AddressBookDTO() { Name = "Standard 1", Email = "Test1@gmail.com", Address = "11 Maadi , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Sales Manager", institution = "High Tech" });
                defaultStandards.Add(new AddressBookDTO() { Name = "Standard 2", Email = "Test2@gmail.com", Address = "12 Feal , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Sales Manager", institution = "High Tech" });
                defaultStandards.Add(new AddressBookDTO() { Name = "Standard 3", Email = "Test3@gmail.com", Address = "87 Dooki , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Sales Manager", institution = "High Tech" });

                foreach (AddressBookDTO item in defaultStandards)
                    context.AddressBook.Add(item);

                base.Seed(context);
            }
        }
    }
}
