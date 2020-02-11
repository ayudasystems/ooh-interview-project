using System;
using OohInterview.DAL.Pocos;

namespace OohInterview.DAL.Builders
{
    public class FaceBuilder
    {
        private const string DefaultDescription = "face description";

        private readonly DataContext _context;
        private readonly Face _face;

        public FaceBuilder(DataContext context)
        {
            _context = context;
            _face = new Face();
            SetDefaults();
        }

        public FaceBuilder WithId(Guid faceId)
        {
            _face.Id = faceId;
            return this;
        }

        public FaceBuilder WithName(string name)
        {
            _face.Name = name;
            return this;
        }

        public Face Build()
        {
            _context.Faces.Add(_face);
            return _face;
        }

        private void SetDefaults()
        {
            WithId(Guid.NewGuid())
                .WithName(DefaultDescription);
        }
    }
}