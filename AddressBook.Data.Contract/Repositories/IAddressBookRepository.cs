using AddressBook.DTO;
using System.Linq;

namespace AddressBook.Data.Contract.Repositories
{
    /// <summary>
    ///  This Interface have the operations required for dealing with database .
    /// </summary>
    public interface IAddressBookRepository
    {
        IQueryable<AddressBookDTO> GetAddressBook();

        AddressBookDTO GetAddressBook(int id);

        AddressBookDTO EditAddressBook( AddressBookDTO addressBook);

        AddressBookDTO SaveAddressBook(AddressBookDTO addressBook);

        AddressBookDTO DeleteAddressBook(int id);
    }
}
