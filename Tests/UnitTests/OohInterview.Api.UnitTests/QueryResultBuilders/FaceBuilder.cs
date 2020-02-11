using System;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Api.UnitTests.QueryResultBuilders
{
    public class FaceBuilder
    {
        private const string DefaultDescription = "face description";

        private Guid _id;
        private string _name;

        public FaceBuilder()
        {
            _id = Guid.NewGuid();
            _name = DefaultDescription;
        }

        public FaceBuilder WithId(Guid faceId)
        {
            _id = faceId;
            return this;
        }

        public FaceBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public ListFacesResult.Face Build()
        {
            return new ListFacesResult.Face(_id, _name);
        }
    }
}