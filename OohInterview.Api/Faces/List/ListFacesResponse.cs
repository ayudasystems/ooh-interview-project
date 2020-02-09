using System.Collections.Generic;
using System.Linq;
using OohInterview.Api.Common.Responses;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Api.Faces.List
{
    public class ListFacesResponse : CollectionResponse<ListFacesResponse.FaceResponse>
    {
        public ListFacesResponse(List<FaceResponse> items)
            : base(items)
        {
        }

        public static ListFacesResponse FromQuery(ListFacesResult result)
        {
            var response =
                result.Faces
                    .Select(FaceResponse.From)
                    .ToList();

            return new ListFacesResponse(response);
        }

        public class FaceResponse
        {
            public string Id { get; }
            public string Name { get; }

            public FaceResponse(string id, string name)
            {
                Id = id;
                Name = name;
            }

            public static FaceResponse From(ListFacesResult.Face face)
            {
                return new FaceResponse(
                    face.Id.ToString(),
                    face.Name
                );
            }
        }
    }
}