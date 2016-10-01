using AddressBook.DTO;
using System.Linq;

namespace AddressBook.Business.Contract.Managers
{

    /// <summary>
    /// This Interface have the operations required for business logic .
    /// </summary>
    public interface IAddressBookManager
    {
        IQueryable<AddressBookDTO> GetAddressBook();

        AddressBookDTO GetAddressBook(int id);

        AddressBookDTO EditAddressBook( AddressBookDTO addressBook);

        AddressBookDTO SaveAddressBook(AddressBookDTO addressBook);

        AddressBookDTO DeleteAddressBook(int id);

    }
}
