using AddressBook.Business.Contract.Managers;
using AddressBook.DTO;
using AddressBook.WebApp.Controllers;
using Moq;
using System.Collections.Generic;


namespace AddressBook.WebApp.Test.Helper
{
    public static class AddressBookHelper
    {
        public static AddressBookDTO CreateAddressBookInstance()
        {
            return new AddressBookDTO() { Email = "Test1@gmail.com", Address = "11 Maadi , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Sales Manager", institution = "High Tech" };
        }
        public static List<AddressBookDTO>CreateListAddressBook()
        {
            return new List<AddressBookDTO>()      {
       new AddressBookDTO() { Name = "Standard 1", Email = "Test1@gmail.com", Address = "11 Maadi , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Sales Manager", institution = "High Tech" },
       new AddressBookDTO() { Name = "Standard 2", Email = "Test2@Yahoo.com", Address = "12 Feal , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Developer", institution = "Microsoft" },
       new AddressBookDTO() { Name = "Standard 3", Email = "Test3@Hotmail.com", Address = "87 Dooki , Cairo,Egypt", PhoneNumber = "01005741239", JobPosition = "Teacher", institution = "First School" }
            };
        }

        public static Mock<IAddressBookManager> CreateAddressBookMockObject()
        {
            return new Mock<IAddressBookManager> ();
        }
        public static AddressBookController CreateAddressBookControllerInstance()
        {
            return new AddressBookController(CreateAddressBookMockObject().Object);
        }
        public static AddressBookController CreateAddressBookControllerInstance(IAddressBookManager addressBookManager)
        {
            return new AddressBookController(addressBookManager);
        }
    }
}
