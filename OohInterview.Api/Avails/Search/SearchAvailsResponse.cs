using System.Collections.Generic;
using OohInterview.Api.Common.Responses;

namespace OohInterview.Api.Avails.Search
{
    public class SearchAvailsResponse : CollectionResponse<SearchAvailsResponse.AvailsResponse>
    {
        public SearchAvailsResponse(List<AvailsResponse> items) : base(items)
        {
        }
        
        public class AvailsResponse
        {
            public string FaceId { get; }
            public bool IsAvailable { get; }

            public AvailsResponse(string faceId, bool isAvailable)
            {
                FaceId = faceId;
                IsAvailable = isAvailable;
            }
        }
    }
}