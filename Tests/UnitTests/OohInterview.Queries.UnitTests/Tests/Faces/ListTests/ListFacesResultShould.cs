using System;
using System.Collections.Generic;
using OohInterview.Queries.Faces.List;
using Xunit;

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

        private static IEnumerable<ListFacesResult.Face> CreateMultipleFaces(int numberOfFaces)
        {
            var faces = new List<ListFacesResult.Face>(numberOfFaces);
            for (var i = 0; i < numberOfFaces; i++)
            {
                faces.Add(new ListFacesResult.Face(Guid.NewGuid(), $"Face {i}"));
            }

            return faces;
        }
    }
}