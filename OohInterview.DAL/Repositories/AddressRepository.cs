using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public class AddressRepository: IAddressRepository
    {
        private readonly DataContext _dataContext;

        public AddressRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IEnumerable<Address> GetAddresses()
        {
            return _dataContext.Addresses;
        }

        public void AddAddress(Address address)
        {
            _dataContext.Addresses.Add(address);
        }
    }
}