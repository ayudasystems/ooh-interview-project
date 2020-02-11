using System;
using System.Net.Http;
using System.Threading.Tasks;
using OohInterview.Api.Faces.List;
using OohInterview.Api.IntegrationTests.Assertions;
using OohInterview.DAL.Builders;
using Xunit;

namespace OohInterview.Api.IntegrationTests.Tests.Faces.List
{
    public class ListFacesShould : BaseIntegrationTest
    {
        private const string Endpoint = "faces";

        [Fact]
        public async Task ReturnA200Response()
        {
            var url = CreateUrl(Endpoint);
            var response = await Client.GetAsync(url);
            response.AssertSuccessResponse();
        }

        [Fact]
        public async Task ReturnAllOfTheFaces()
        {
            new FaceBuilder(DataContext).Build();
            new FaceBuilder(DataContext).Build();

            var faces = await GetFaces();

            Assert.Equal(2, faces.Items.Count);
        }

        [Fact]
        public async Task ReturnTheCorrectName()
        {
            const string name = "A Test Face Name";
            new FaceBuilder(DataContext)
                .WithName(name)
                .Build();

            var response = await GetFaces();

            var face = Assert.Single(response.Items);
            Assert.Equal(name, face.Name);
        }

        [Fact]
        public async Task ReturnTheCorrectId()
        {
            var id = Guid.NewGuid();
            new FaceBuilder(DataContext)
                .WithId(id)
                .Build();

            var response = await GetFaces();

            var face = Assert.Single(response.Items);
            Assert.Equal(id.ToString(), face.Id);
        }

        private async Task<ListFacesResponse> GetFaces()
        {
            var response = await Client.GetAsync(CreateUrl(Endpoint));
            response.AssertSuccessResponse();

            return await Deserialize(response);
        }

        private Task<ListFacesResponse> Deserialize(HttpResponseMessage response)
        {
            return response.AssertCollectionResponseType<ListFacesResponse, ListFacesResponse.FaceResponse>();
        }
    }
}