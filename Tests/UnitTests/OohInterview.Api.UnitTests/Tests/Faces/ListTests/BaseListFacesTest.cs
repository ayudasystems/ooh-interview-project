using System.Collections.Generic;
using OohInterview.Api.UnitTests.QueryResultBuilders;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Api.UnitTests.Tests.Faces.ListTests
{
    public abstract class BaseListFacesTest
    {
        protected static ListFacesResult CreateQueryResultWithFaces(int numberOfFaces)
        {
            var faces = new List<ListFacesResult.Face>(numberOfFaces);
            for (var i = 0; i < numberOfFaces; i++)
            {
                var face = new FaceBuilder()
                    .WithName($"Face {i}")
                    .Build();
                faces.Add(face);
            }

            return new ListFacesResult(faces);
        }
    }
}