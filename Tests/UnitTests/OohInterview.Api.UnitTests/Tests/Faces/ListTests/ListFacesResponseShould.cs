using System;
using OohInterview.Api.Faces.List;
using OohInterview.Api.UnitTests.QueryResultBuilders;
using OohInterview.Queries.Faces.List;
using Xunit;

namespace OohInterview.Api.UnitTests.Tests.Faces.ListTests
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
            var queryFace = new FaceBuilder().WithId(Guid.NewGuid()).Build();
            var queryResult = new ListFacesResult(new[] { queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(queryFace.Id.ToString(), responseFace.Id);
        }

        [Fact]
        public void SetTheName()
        {
            var queryFace = new FaceBuilder().WithName("Expected Face Name").Build();
            var queryResult = new ListFacesResult(new[] { queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(queryFace.Name, responseFace.Name);
        }
    }
}