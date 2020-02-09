using System.Collections.Generic;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Repositories
{
    public interface IFaceRepository
    {
        IEnumerable<Face> GetFaces();
        void AddFace(Face face);
    }
}