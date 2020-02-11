using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Moq;
using OohInterview.DAL.Pocos;
using OohInterview.DAL.Repositories;
using OohInterview.Queries.Implementation.Faces.List;
using Xunit;

namespace OohInterview.Queries.Implementation.UnitTests.Tests.Faces
{
    public class ListFacesShould
    {
        private readonly ListFaces _listFaces;
        private readonly Mock<IFaceRepository> _faceRepository;

        public ListFacesShould()
        {
            _faceRepository = new Mock<IFaceRepository>(MockBehavior.Strict);
            _listFaces = new ListFaces(_faceRepository.Object);
        }

        [Fact]
        public void ReturnAnEmptyResultWhenNoFacesExist()
        {
            SetupNoFaces();

            var result = _listFaces.List(CancellationToken.None);

            Assert.Empty(result.Faces);
        }

        private void SetupNoFaces()
        {
            SetupFaces(Enumerable.Empty<Face>());
        }

        private void SetupFaces(IEnumerable<Face> faces)
        {
            _faceRepository
                .Setup(x => x.GetFaces())
                .Returns(faces);
        }
    }
}