using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook.DTO;
using Moq;
using AddressBook.Business.Contract.Managers;
using System.Web.Mvc;
using AddressBook.WebApp.Test.Helper;

namespace AddressBook.WebApp.Test
{
    [TestClass]
    public class CreateViewTest
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
        public void TestCreateMethodWithRedirectToIndexActionIncaseSuccessfullyOperation()
        {
            addressManagerMock.Setup(e => e.SaveAddressBook(addressBookObj)).Returns(addressBookObj);

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {
                // Act 
                var result = controller.Create(addressBookObj) as RedirectToRouteResult;

                // Assert
                Assert.AreEqual("Index", result.RouteValues["action"]);
                Assert.IsNull(result.RouteValues["controller"]); // means we redirected to the same controller
            }
        }

        [TestMethod]
        public void TestCreateMethodWithRedirectToCreateViewIncaseUnsuccessfullyOperation()
        {

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {

                // What I'm doing is setting up the situation: my controller is receiving an invalid model.
                controller.ModelState.AddModelError("NameRequired", "Name is required");
                // Act 
                var result = controller.Create(addressBookObj) as ViewResult;

                // Assert

                Assert.AreEqual("Create", result.ViewName);
            }
        }
        [TestMethod]
        public void TestCreateMethodToCheckModelTypeBindToViewIncaseSuccessfullyOperation()
        {

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {

                // What I'm doing is setting up the situation: my controller is receiving an invalid model.
                controller.ModelState.AddModelError("NameRequired", "Name is required");
                // Act 
                var result = controller.Create(addressBookObj) as ViewResult;

                // Assert

                Assert.IsInstanceOfType(result.Model, typeof(AddressBookDTO));
            }
        }
    }
}
