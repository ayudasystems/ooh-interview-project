using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OohInterview.Api.Avails.Search
{
    public class SearchAvailsQueryParameters
    {
        public string? StartDate { get; set; }
        
        public string? EndDate { get; set; }
        
        public string? FaceIds { get; set; }
    }
}