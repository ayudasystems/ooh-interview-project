using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAddresses();
        void AddAddress(Address address);
    }
}