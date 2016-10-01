using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook.DTO;
using Moq;
using AddressBook.Business.Contract.Managers;
using System.Web.Mvc;
using AddressBook.WebApp.Test.Helper;

namespace AddressBook.WebApp.Test
{
    [TestClass]
    public class DetailsViewTest
    {
        private Mock<IAddressBookManager> addressManagerMock;
        private AddressBookDTO addressBookObj;

        [TestInitialize]
        public void TestInitialize()
        {
            addressManagerMock =  AddressBookHelper.CreateAddressBookMockObject();

            addressBookObj =  AddressBookHelper.CreateAddressBookInstance();

        }


        [TestMethod]
        public void TestDetailsWithIdReturnViewResult()
        {
            // Arrange


            // Mock<IAddressBookManager> faqManager = GetMockMangerInstance();

            addressManagerMock.Setup(e => e.GetAddressBook(addressBookObj.Id)).Returns(addressBookObj);

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {

                // Act
                var result = controller.Details(addressBookObj.Id) as ViewResult;

                // Assert
                Assert.IsInstanceOfType(result, typeof(ViewResult));
            }
        }


        [TestMethod]
        public void TestDetailsWithReturnCorrectView()
        {
            // Arrange

            addressManagerMock.Setup(e => e.GetAddressBook(addressBookObj.Id)).Returns(addressBookObj);
            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {
                // Act
                var result = controller.Details(addressBookObj.Id) as ViewResult;

                // Assert

                Assert.AreEqual("Details", result.ViewName);
            }
        }

    }
}
