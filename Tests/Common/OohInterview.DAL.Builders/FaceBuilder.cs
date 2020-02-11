using System;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Builders
{
    public class FaceBuilder
    {
        private const string DefaultName = "face description";

        private Guid _id;
        private string _name;

        public FaceBuilder()
        {
            _id = Guid.NewGuid();
            _name = DefaultName;
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

        public Face Build()
        {
            return new Face()
            {
                Id = _id,
                Name = _name
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