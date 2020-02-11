using System;
using System.Net.Http;
using System.Threading.Tasks;
using OohInterview.Api.Common.Responses;

namespace OohInterview.Api.IntegrationTests.Assertions
{
    public static class ResponseAssertions
    {
        public static async Task<TResponse> AssertCollectionResponseType<TResponse, TModel>(this HttpResponseMessage response)
            where TResponse : CollectionResponse<TModel>
            where TModel : class
        {
            var result = await AssertResponseType<TResponse>(response);
            if (result.Items == null)
                await ThrowExceptionWithResponse(response, $"Response body does not contain a '{nameof(result.Items)}' property");

            return result;
        }

        public static async Task<T> AssertResponseType<T>(this HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsAsync<T>();
            if (result == null)
                await ThrowExceptionWithResponse(response, "Deserialization of the response body failed");

            return result;
        }

        private static async Task ThrowExceptionWithResponse(HttpResponseMessage response, string message)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            throw new Exception($"{message}:{Environment.NewLine}{responseBody}");
        }
    }
}