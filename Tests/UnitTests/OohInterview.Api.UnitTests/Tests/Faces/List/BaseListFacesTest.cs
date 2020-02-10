using System;
using OohInterview.Queries.Faces.List;
using Face = OohInterview.Queries.Faces.List.ListFacesResult.Face;

namespace OohInterview.Api.UnitTests.Tests.Faces.List
{
    public abstract class BaseListFacesTest
    {
        protected static ListFacesResult CreateQueryResultWithFaces(int numberOfFaces)
        {
            var faces = new Face[numberOfFaces];
            for (var i = 0; i < numberOfFaces; i++)
            {
                faces[i] = CreateFace(name: $"Face {i}");
            }
            return new ListFacesResult(faces);
        }

        protected static Face CreateFace(Guid? id = null, string? name = null)
        {
            return new Face(id ?? Guid.NewGuid(), name ?? "A Billboard");
        }
    }
}