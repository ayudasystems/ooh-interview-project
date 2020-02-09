using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Queries.Implementation.Faces.List
{
    public class ListFaces : IListFaces
    {
        public ListFacesResult List(CancellationToken cancellationToken)
        {

            return new ListFacesResult(new List<ListFacesResult.Face>());
        }
    }
}