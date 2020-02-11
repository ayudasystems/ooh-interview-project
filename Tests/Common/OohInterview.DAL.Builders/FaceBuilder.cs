using System;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Builders
{
    public class FaceBuilder
    {
        private const string DefaultName = "face description";
        private const decimal DefaultRate = 111.22m;

        private Guid _id;
        private string _name;
        private decimal _ratePerDay;

        public FaceBuilder()
        {
            _id = Guid.NewGuid();
            _name = DefaultName;
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

        public Face Build()
        {
            return new Face()
            {
                Id = _id,
                Name = _name,
                RatePerDay = _ratePerDay
            };
        }

        public Face BuildAndAddToContext(DataContext context)
        {
            var poco = Build();
            context.Faces.Add(poco);

            return poco;
        }
    }
}