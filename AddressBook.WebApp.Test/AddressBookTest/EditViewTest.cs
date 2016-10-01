using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook.DTO;
using Moq;
using AddressBook.Business.Contract.Managers;
using System.Web.Mvc;
using System.Net;
using AddressBook.WebApp.Test.Helper;

namespace AddressBook.WebApp.Test.AddressBookTest
{
    [TestClass]
    public class EditViewTest
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
        public void TestEditByIdMethodWithThrowBadRequestIncaseNullIdParameter()
        {
            int? intValue = null;

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {

                // Act 
                var result = controller.Edit(intValue) as HttpStatusCodeResult;

                // Assert

                Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.BadRequest);
            }
        }
        [TestMethod]
        public void TestEditByIdMethodWithThrowHttpNotFoundIncaseNullObjectParameter()
        {
            AddressBookDTO facAddressBookObj = null;
            addressManagerMock.Setup(e => e.GetAddressBook(addressBookObj.Id)).Returns(facAddressBookObj);
            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {

                // Act 
                var result = controller.Edit(addressBookObj.Id) as HttpNotFoundResult;

                // Assert

                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            }
        }
        [TestMethod]
        public void TestEditByIdMethodWithRedirectToEditViewIncaseValidOperation()
        {

            addressManagerMock.Setup(e => e.GetAddressBook(addressBookObj.Id)).Returns(addressBookObj);
            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {

                // Act 
                var result = controller.Edit(addressBookObj.Id) as ViewResult;

                // Assert

                Assert.AreEqual("Edit", result.ViewName);
            }
        }
        [TestMethod]
        public void TestEditMethodWithRedirectToIndexActionIncaseSuccessfullyOperation()
        {
            addressManagerMock.Setup(e => e.EditAddressBook(addressBookObj)).Returns(addressBookObj);
            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {
                // Act 
                var result = controller.Edit(addressBookObj) as RedirectToRouteResult;

                // Assert
                Assert.AreEqual("Index", result.RouteValues["action"]);
                Assert.IsNull(result.RouteValues["controller"]); // means we redirected to the same controller

            }
        }
        [TestMethod]
        public void TestEditMethodWithRedirectToEditViewIncaseUnsuccessfullyOperation()
        {

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {
                controller.ModelState.AddModelError("NameRequired", "Name is required");
                // Act 
                var result = controller.Edit(addressBookObj) as ViewResult;

                // Assert
                Assert.AreEqual("Edit", result.ViewName);
            }
        }
        [TestMethod]
        public void TestEditMethodToCheckModelTypeBindToViewIncaseSuccessfullyOperation()
        {

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {
                controller.ModelState.AddModelError("NameRequired", "Name is required");
                // Act 
                var result = controller.Edit(addressBookObj) as ViewResult;

                // Assert

                Assert.IsInstanceOfType(result.Model, typeof(AddressBookDTO));
            }
        }

    }
}
