using AddressBook.Business.Contract.Managers;
using AddressBook.DTO;
using AddressBook.WebApp.Test.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AddressBook.WebApp.Test
{
    [TestClass]
    public class IndexViewTest
    {
        private Mock<IAddressBookManager> addressManagerMock;
    

        private List<AddressBookDTO> listAddressBook;
        [TestInitialize]
        public void TestInitialize()
        {
            addressManagerMock =  AddressBookHelper.CreateAddressBookMockObject();

            listAddressBook =  AddressBookHelper.CreateListAddressBook();
        }
        [TestMethod]
        public void TestIndex()
        {
            // Arrange

            addressManagerMock.Setup(e => e.GetAddressBook()).Returns(listAddressBook.AsQueryable());

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {

                // Act 
                var result = controller.Index() as ViewResult;

                var model = result.Model as IEnumerable<AddressBookDTO>;
                // Assert
                Assert.IsNotNull(result);

                Assert.AreEqual(3, model.Count());
            }
        }

    }
}
