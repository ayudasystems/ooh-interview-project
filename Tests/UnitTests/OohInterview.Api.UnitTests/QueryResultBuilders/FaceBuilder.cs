using System;
using OohInterview.Queries.Faces.List;

namespace OohInterview.Api.UnitTests.QueryResultBuilders
{
    public class FaceBuilder
    {
        private const string DefaultDescription = "face description";
        private const decimal DefaultRate = 123.09m;

        private Guid _id;
        private string _name;
        private decimal _ratePerDay;

        public FaceBuilder()
        {
            _id = Guid.NewGuid();
            _name = DefaultDescription;
            _ratePerDay = DefaultRate;
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

        public FaceBuilder WithRatePerDay(decimal ratePerDay)
        {
            _ratePerDay = ratePerDay;
            return this;
        }

        public ListFacesResult.Face Build()
        {
            return new ListFacesResult.Face(_id, _name, _ratePerDay);
        }
    }
}