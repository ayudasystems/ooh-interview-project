using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Moq;
using OohInterview.DAL.Builders;
using OohInterview.DAL.Pocos;
using OohInterview.DAL.Repositories;
using OohInterview.Queries.Implementation.Faces.List;
using Xunit;

namespace OohInterview.Queries.Implementation.UnitTests.Tests.Faces
{
    public class ListFacesShould
    {
        private readonly ListFaces _listFaces;
        private readonly Mock<IFaceRepository> _faceRepository;

        public ListFacesShould()
        {
            _faceRepository = new Mock<IFaceRepository>(MockBehavior.Strict);
            _listFaces = new ListFaces(_faceRepository.Object);
        }

        [Fact]
        public void ReturnAnEmptyResultWhenNoFacesExist()
        {
            SetupNoFaces();

            var result = _listFaces.List();

            Assert.Empty(result.Faces);
        }

        [Fact]
        public void ReturnTheCorrectNumberOfFaces()
        {
            const int expectedFaceCount = 3;
            SetupMultipleFaces(3);

            var result = _listFaces.List();

            Assert.Equal(expectedFaceCount, result.Faces.Count);
        }

        [Fact]
        public void ReturnTheCorrectId()
        {
            var expectedId = Guid.NewGuid();
            var face = new FaceBuilder().WithId(expectedId).Build();
            SetupFaces(new[] { face });

            var result = _listFaces.List();

            var resultFace = Assert.Single(result.Faces);
            Assert.Equal(expectedId, resultFace.Id);
        }

        [Fact]
        public void ReturnTheCorrectName()
        {
            const string expectedName = "An Expected Face";
            var face = new FaceBuilder().WithName(expectedName).Build();
            SetupFaces(new[] { face });

            var result = _listFaces.List();

            var resultFace = Assert.Single(result.Faces);
            Assert.Equal(expectedName, resultFace.Name);
        }

        [Fact]
        public void ReturnTheCorrectRatePerDay()
        {
            const decimal expectedRate = 135.79m;
            var face = new FaceBuilder().WithRatePerDay(expectedRate).Build();
            SetupFaces(new[] { face });

            var result = _listFaces.List();

            var resultFace = Assert.Single(result.Faces);
            Assert.Equal(expectedRate, resultFace.RatePerDay);
        }

        private void SetupNoFaces()
        {
            SetupFaces(Enumerable.Empty<Face>());
        }

        private void SetupMultipleFaces(int numberOfFaces)
        {
            var faces = new List<Face>(numberOfFaces);
            for (var i = 0; i < numberOfFaces; i++)
            {
                var face = new FaceBuilder().WithName($"Face {i}").Build();
                faces.Add(face);
            }

            SetupFaces(faces);
        }

        private void SetupFaces(IEnumerable<Face> faces)
        {
            _faceRepository
                .Setup(x => x.GetFaces())
                .Returns(faces);
        }
    }
}