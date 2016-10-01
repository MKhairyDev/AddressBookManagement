
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AddressBook.DTO;
using AddressBook.Business.Contract.Managers;

namespace AddressBook.WebApp.Controllers
{
    public class AddressBookController : Controller
    {
        private IAddressBookManager addressBookManager;
        public AddressBookController(IAddressBookManager addressBookManager)
        {
            this.addressBookManager = addressBookManager;
        }
        // GET: AddressBook
        public ActionResult Index()
        {
            return View( addressBookManager.GetAddressBook().ToList());
        }

        // GET: AddressBook/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressBookDTO addressBookDto = addressBookManager.GetAddressBook(id.Value);
            if (addressBookDto == null)
            {
                return HttpNotFound();
            }
            return View("Details",addressBookDto);
        }

        // GET: AddressBook/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressBook/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressBookDTO addressBook)
        {

            if (ModelState.IsValid)
            {
                addressBookManager.SaveAddressBook(addressBook);
                return RedirectToAction("Index");
            }

            return View("Create", addressBook);
        }

        // GET: AddressBook/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressBookDTO addressBookDto = addressBookManager.GetAddressBook(id.Value);
            if (addressBookDto == null)
            {
                return HttpNotFound();
            }
            return View("Edit",addressBookDto);
        }

        // POST: AddressBook/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressBookDTO addressBook)
        {
            if (ModelState.IsValid)
            {
                addressBookManager.EditAddressBook(addressBook);
                return RedirectToAction("Index");
            }
            return View("Edit",addressBook);
        }

        // GET: AddressBook/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressBookDTO addressBookDto = addressBookManager.GetAddressBook(id.Value);
            if (addressBookDto == null)
            {
                return HttpNotFound();
            }
            return View("Delete",addressBookDto);
        }

        // POST: AddressBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
             addressBookManager.DeleteAddressBook(id);
            return RedirectToAction("Index");
        }



    }
}
