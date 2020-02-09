using System.Threading;
using System.Threading.Tasks;

namespace OohInterview.Queries.Faces.List
{
    public interface IListFaces
    {
        ListFacesResult List( CancellationToken cancellationToken);
    }
}