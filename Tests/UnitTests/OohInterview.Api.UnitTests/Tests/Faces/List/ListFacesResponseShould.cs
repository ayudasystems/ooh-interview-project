using System;
using OohInterview.Api.Faces.List;
using OohInterview.Queries.Faces.List;
using Xunit;

namespace OohInterview.Api.UnitTests.Tests.Faces.List
{
    public class ListFacesResponseShould : BaseListFacesTest
    {
        [Fact]
        public void SetTheCorrectNumberOfItems()
        {
            const int expectedCount = 3;
            var queryResult = CreateQueryResultWithFaces(expectedCount);

            var response = ListFacesResponse.FromQuery(queryResult);
            
            Assert.Equal(expectedCount, response.Items.Count);
        }

        [Fact]
        public void SetTheId()
        {
            var queryFace = CreateFace(Guid.NewGuid());
            var queryResult = new ListFacesResult(new []{ queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(queryFace.Id.ToString(), responseFace.Id);
        }

        [Fact]
        public void SetTheName()
        {
            var queryFace = CreateFace(name: "Expected Face Name");
            var queryResult = new ListFacesResult(new []{ queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(queryFace.Name, responseFace.Name);
        }
    }
}