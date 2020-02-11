using System;
using OohInterview.Queries.Faces.List;
using Xunit;

namespace OohInterview.Queries.UnitTests.Tests.Faces.ListTests
{
    public class FaceShould
    {
        private static readonly Guid ValidId = Guid.NewGuid();
        private const string ValidName = "Highway Billboard";

        [Fact]
        public void BeCreatedSuccessfully()
        {
            var face = new ListFacesResult.Face(ValidId, ValidName);

            Assert.NotNull(face);
        }

        [Fact]
        public void SetTheId()
        {
            var expectedId = Guid.NewGuid();

            var face = new ListFacesResult.Face(expectedId, ValidName);

            Assert.Equal(expectedId, face.Id);
        }

        [Fact]
        public void SetTheName()
        {
            const string expectedName = "Expected Face Name";

            var face = new ListFacesResult.Face(ValidId, expectedName);

            Assert.Equal(expectedName, face.Name);
        }

        [Fact]
        public void FailWhenTheIdIsEmpty()
        {
            var invalidId = Guid.Empty;

            Assert.Throws<ArgumentException>(
                () => new ListFacesResult.Face(invalidId, ValidName));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FailWhenTheNameIsInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => new ListFacesResult.Face(ValidId, invalidName));
        }
    }
}