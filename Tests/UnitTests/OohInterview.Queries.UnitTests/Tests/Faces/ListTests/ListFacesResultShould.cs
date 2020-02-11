using System;
using System.Collections.Generic;
using OohInterview.Queries.Faces.List;
using Xunit;
using Face = OohInterview.Queries.Faces.List.ListFacesResult.Face;

namespace OohInterview.Queries.UnitTests.Tests.Faces.ListTests
{
    public class ListFacesResultShould
    {
        [Fact]
        public void ReturnNoFacesWhenQueryReturnsNothing()
        {
            var emptyFaces = new List<ListFacesResult.Face>(0);

            var result = new ListFacesResult(emptyFaces);

            Assert.Empty(result.Faces);
        }

        [Fact]
        public void ReturnTheCorrectAmountOfFaces()
        {
            const int numberOfFaces = 3;
            var faces = CreateMultipleFaces(numberOfFaces);

            var result = new ListFacesResult(faces);

            Assert.Equal(numberOfFaces, result.Faces.Count);
        }

        private static IEnumerable<Face> CreateMultipleFaces(int numberOfFaces)
        {
            var faces = new List<Face>(numberOfFaces);
            for (var i = 0; i < numberOfFaces; i++)
            {
                faces.Add(new Face(Guid.NewGuid(), $"Face {i}", 0m));
            }

            return faces;
        }
    }
}