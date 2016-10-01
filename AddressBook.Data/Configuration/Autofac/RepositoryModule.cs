using AddressBook.Data.Contract.Repositories;
using AddressBook.Data.Repositories;
using Autofac;


namespace AddressBook.Data.Configuration.Autofac
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddressBookRepository>().As<IAddressBookRepository>().InstancePerRequest();
        }
    }
}
