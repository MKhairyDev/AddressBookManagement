using AddressBook.Data.Contract.Repositories;
using AddressBook.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Data.Repositories
{
    /// <summary>
    /// From this layer we can deal with databse using Entity FrameWork.
    /// </summary>
    public class AddressBookRepository : IAddressBookRepository,IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        private AddressBookContext db ;
       public AddressBookRepository()
        {
            db = new AddressBookContext();
        }
        public AddressBookContext Db
        {
            get
            {
                return db;
            }

            set
            {
                db = value;
            }
        }

        public IQueryable<AddressBookDTO> GetAddressBook()
        {
            return Db.AddressBook;
        }

        public AddressBookDTO GetAddressBook(int id)
        {
            AddressBookDTO addressBookDto = Db.AddressBook.Find(id);

            return addressBookDto;
        }



        public AddressBookDTO EditAddressBook(AddressBookDTO addressBook)
        {
            Db.Entry(addressBook).State = EntityState.Modified;

            try
            {
                return Db.SaveChanges() == 1 ? addressBook : null;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;

            }
        }


        public AddressBookDTO SaveAddressBook(AddressBookDTO addressBook)
        {
            Db.AddressBook.Add(addressBook);
            return Db.SaveChanges() == 1 ? addressBook : null;
        }
        public AddressBookDTO DeleteAddressBook(int id)
        {
            AddressBookDTO addressBook = Db.AddressBook.Find(id);
            if (addressBook == null)
            {
                return null;
            }

            Db.AddressBook.Remove(addressBook);
            return Db.SaveChanges() == 1 ? addressBook : null;
        }
   
   
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                db.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
