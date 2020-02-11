using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OohInterview.Api.Faces.List;
using OohInterview.Api.UnitTests.Assertions;
using OohInterview.Api.UnitTests.QueryResultBuilders;
using OohInterview.Queries.Faces.List;
using Xunit;
using Face = OohInterview.Queries.Faces.List.ListFacesResult.Face;

namespace OohInterview.Api.UnitTests.Tests.Faces.ListTests
{
    public class ListFacesShould : BaseListFacesTest
    {
        private readonly ListFacesController _controller;
        private readonly Mock<IListFaces> _listFacesQuery;

        public ListFacesShould()
        {
            _listFacesQuery = new Mock<IListFaces>(MockBehavior.Strict);
            _controller = new ListFacesController(_listFacesQuery.Object);
        }

        [Fact]
        public void ReturnA200ResponseCodeWhenSuccessful()
        {
            SetupQueryReturnsNoFaces();

            var response = _controller.ListFaces();

            response.Assert200();
        }

        [Fact]
        public void ReturnAnEmptyListWhenNoFacesExist()
        {
            SetupQueryReturnsNoFaces();

            var response = _controller.ListFaces();

            var listFacesResponse = GetResponseContents(response);
            Assert.Empty(listFacesResponse.Items);
        }

        [Fact]
        public void ReturnMultipleFaces()
        {
            const int faceCount = 3;
            SetupMultipleFaces(faceCount);

            var response = _controller.ListFaces();

            var listFacesResponse = GetResponseContents(response);
            Assert.Equal(faceCount, listFacesResponse.Items.Count);
        }

        [Fact]
        public void ReturnTheCorrectId()
        {
            var queryFace = new FaceBuilder().WithId(Guid.NewGuid()).Build();
            SetupFace(queryFace);

            var response = _controller.ListFaces();

            var listFacesResponse = GetResponseContents(response);
            var face = Assert.Single(listFacesResponse.Items);
            Assert.Equal(queryFace.Id.ToString(), face.Id);
        }

        [Fact]
        public void ReturnTheCorrectName()
        {
            var queryFace = new FaceBuilder().WithName("An Expected Face").Build();
            SetupFace(queryFace);

            var response = _controller.ListFaces();

            var listFacesResponse = GetResponseContents(response);
            var face = Assert.Single(listFacesResponse.Items);
            Assert.Equal(queryFace.Name, face.Name);
        }

        private ListFacesResponse GetResponseContents(ActionResult<ListFacesResponse> response)
        {
            return response.AssertOkObjectResponse();
        }

        private void SetupQueryReturnsNoFaces()
        {
            var emptyFaces = new ListFacesResult(Enumerable.Empty<Face>());
            SetupQueryResult(emptyFaces);
        }

        private void SetupFace(Face face)
        {
            var queryResult = new ListFacesResult(new[] { face });
            SetupQueryResult(queryResult);
        }

        private void SetupMultipleFaces(int faceCount)
        {
            var facesResult = CreateQueryResultWithFaces(faceCount);
            SetupQueryResult(facesResult);
        }

        private void SetupQueryResult(ListFacesResult facesResult)
        {
            _listFacesQuery.Reset();
            _listFacesQuery
                .Setup(
                    x => x.List())
                .Returns(facesResult);
        }
    }
}