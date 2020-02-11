using System.Collections.Generic;
using OohInterview.DAL.Builders;
using OohInterview.DAL.Pocos;
using OohInterview.DAL.Repositories;
using OohInterview.DAL.UnitTests.Mocks;
using Xunit;

namespace OohInterview.DAL.UnitTests.Tests.Repositories
{
    public class FaceRepositoryShould
    {
        private readonly FaceRepository _faceRepository;
        private readonly MockDataContext _context;

        public FaceRepositoryShould()
        {
            _context = new MockDataContext();
            _faceRepository = new FaceRepository(_context);
        }

        [Fact]
        public void ReturnTheFaces()
        {
            var expectedFaces = SetupMultipleFaces(3);

            var resultFaces = _faceRepository.GetFaces();

            Assert.Equal(expectedFaces, resultFaces);
        }

        [Fact]
        public void AddAFace()
        {
            var face = new FaceBuilder().Build();
            Assert.Empty(_context.Faces);

            _context.Faces.Add(face);

            var resultFace = Assert.Single(_context.Faces);
            Assert.Equal(face, resultFace);
        }

        private IEnumerable<Face> SetupMultipleFaces(int numberOfFaces)
        {
            var faces = new List<Face>(numberOfFaces);
            for (int i = 0; i < numberOfFaces; i++)
            {
                var face = new FaceBuilder().WithName($"Face {i}").Build();
                faces.Add(face);
            }

            _context.SetFaces(faces);
            return faces;
        }
    }
}