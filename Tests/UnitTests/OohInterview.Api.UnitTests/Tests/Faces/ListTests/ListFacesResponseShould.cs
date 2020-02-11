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
            var expectedId = Guid.NewGuid();
            var queryFace = new FaceBuilder().WithId(expectedId).Build();
            var queryResult = new ListFacesResult(new[] { queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(expectedId.ToString(), responseFace.Id);
        }

        [Fact]
        public void SetTheName()
        {
            const string expectedName = "An Expected Face";
            var queryFace = new FaceBuilder().WithName(expectedName).Build();
            var queryResult = new ListFacesResult(new[] { queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(expectedName, responseFace.Name);
        }

        [Fact]
        public void SetTheRatePerDay()
        {
            var expectedRate = 444.88m;
            var queryFace = new FaceBuilder().WithRatePerDay(expectedRate).Build();
            var queryResult = new ListFacesResult(new[] { queryFace });

            var response = ListFacesResponse.FromQuery(queryResult);

            var responseFace = Assert.Single(response.Items);
            Assert.Equal(expectedRate, responseFace.RatePerDay);
        }
    }
}