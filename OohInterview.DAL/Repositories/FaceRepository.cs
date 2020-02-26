using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public class FaceRepository: IFaceRepository
    {
        private readonly DataContext _dataContext;

        public FaceRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IEnumerable<Face> GetFaces()
        {
            return _dataContext.Faces;
        }

        public void AddFace(Face face)
        {
            _dataContext.Faces.Add(face);
        }
    }

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