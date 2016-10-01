using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBook.DTO;
using Moq;
using AddressBook.Business.Contract.Managers;
using System.Web.Mvc;
using System.Net;
using AddressBook.WebApp.Test.Helper;

namespace AddressBook.WebApp.Test
{
    [TestClass]
    public class DeleteViewTest
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
        public void TestDeleteMethodWithThrowBadRequestIncaseNullIdParameter()
        {
            int? intValue = null;

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {

                // Act 
                var result = controller.Delete(intValue) as HttpStatusCodeResult;

                // Assert

                Assert.AreEqual(result.StatusCode, (int)HttpStatusCode.BadRequest);
            }
        }
        [TestMethod]
        public void TestDeleteMethodWithThrowHttpNotFoundIncaseNullObjectParameter()
        {
            AddressBookDTO facAddressBookObj = null;
            addressManagerMock.Setup(e => e.GetAddressBook(addressBookObj.Id)).Returns(facAddressBookObj);
            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {

                // Act 
                var result = controller.Delete(addressBookObj.Id) as HttpNotFoundResult;

                // Assert

                Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
            }
        }
        [TestMethod]
        public void TestDeleteMethodWithRedirectToEditViewIncaseValidOperation()
        {

            addressManagerMock.Setup(e => e.GetAddressBook(addressBookObj.Id)).Returns(addressBookObj);
            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance(addressManagerMock.Object))
            {

                // Act 
                var result = controller.Delete(addressBookObj.Id) as ViewResult;

                // Assert

                Assert.AreEqual("Delete", result.ViewName);
            }
        }
        [TestMethod]
        public void TestDeleteConfirmedMethodWithRedirectToIndexAction()
        {

            using (var controller = AddressBookHelper.CreateAddressBookControllerInstance())
            {

                // Act 
                var result = controller.DeleteConfirmed(addressBookObj.Id) as RedirectToRouteResult;

                // Assert
                Assert.AreEqual("Index", result.RouteValues["action"]);
                Assert.IsNull(result.RouteValues["controller"]); // means we redirected to the same controller


            }
        }
    }
}
