using AddressBook.Business.Contract.Managers;
using System.Linq;
using AddressBook.Data.Contract.Repositories;
using AddressBook.DTO;

namespace AddressBook.Business.Managers
{
    /// <summary>
    /// From this layer we can deal with any business logic & call repository Component that deals with database .
    /// </summary>
    public class AddressBookManager : IAddressBookManager
    {
        private readonly IAddressBookRepository addressBookRepository;
            public AddressBookManager(IAddressBookRepository addressBookRepository)
        {
            this.addressBookRepository = addressBookRepository;
        }

        public IQueryable<AddressBookDTO> GetAddressBook()
        {
            return addressBookRepository.GetAddressBook();
        }

        public AddressBookDTO GetAddressBook(int id)
        {
            return addressBookRepository.GetAddressBook(id);
        }


        public AddressBookDTO EditAddressBook( AddressBookDTO addressBook)
        {
            return addressBookRepository.EditAddressBook( addressBook);
        }


        public AddressBookDTO SaveAddressBook(AddressBookDTO addressBook)
        {
            return addressBookRepository.SaveAddressBook(addressBook);
        }

        public AddressBookDTO DeleteAddressBook(int id)
        {
            return addressBookRepository.DeleteAddressBook(id);
        }
    }
}
