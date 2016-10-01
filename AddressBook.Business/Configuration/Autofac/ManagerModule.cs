using AddressBook.Business.Contract.Managers;
using AddressBook.Business.Managers;
using Autofac;


namespace AddressBook.Business.Configuration.Autofac
{
   public class ManagerModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<AddressBookManager>().As<IAddressBookManager>().InstancePerRequest();
        }
    }
}
