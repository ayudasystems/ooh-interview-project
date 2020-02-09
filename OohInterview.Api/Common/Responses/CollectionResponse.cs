using System.Collections.Generic;
using Newtonsoft.Json;

namespace OohInterview.Api.Common.Responses
{
    public class CollectionResponse<T>
        where T : class
    {
        [JsonProperty("items")]
        public List<T> Items { get; }

        public CollectionResponse(List<T> items)
        {
            Items = items;
        }
    }
}