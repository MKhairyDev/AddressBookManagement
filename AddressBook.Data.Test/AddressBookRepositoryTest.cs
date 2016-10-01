using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using AddressBook.Data.Repositories;
using System.Linq;

namespace AddressBook.Data.Test
{
    [TestClass]
    public class AddressBookRepositoryTest
    {
        AddressBookRepository Repo;
        [TestMethod]
        [TestInitialize]
        //To verify database creation
        public void TestSetup()
        {
            AddressBookInitializer db = new AddressBookInitializer();
           Database.SetInitializer(db);
            Repo = new AddressBookRepository();
        }
        [TestMethod]
         //To verify number of rows inserted by the seed method of Address Book Database Initializer
        public void IsRepositoryInitializeWithValidNumberOfData()
        {
            var result = Repo.GetAddressBook();
            Assert.IsNotNull(result);
            var numberOfRecords = result.ToList().Count;
            Assert.AreEqual(3, numberOfRecords);
        }

    }
}
