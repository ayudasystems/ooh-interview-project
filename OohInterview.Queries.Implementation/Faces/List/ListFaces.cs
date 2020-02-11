using System.Linq;
using OohInterview.DAL.Repositories;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Queries.Implementation.Faces.List
{
    public class ListFaces : IListFaces
    {
        private readonly IFaceRepository _faceRepository;

        public ListFaces(IFaceRepository faceRepository)
        {
            _faceRepository = faceRepository;
        }
        public ListFacesResult List()
        {
            var facePocos = _faceRepository.GetFaces();
            var faces = facePocos.Select(f => 
                new ListFacesResult.Face(f.Id, f.Name)
            );
            return new ListFacesResult(faces);
        }
    }
}