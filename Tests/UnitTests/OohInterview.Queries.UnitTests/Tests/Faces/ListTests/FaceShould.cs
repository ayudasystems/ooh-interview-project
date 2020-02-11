using System;
using Xunit;
using Face = OohInterview.Queries.Faces.List.ListFacesResult.Face;

namespace OohInterview.Queries.UnitTests.Tests.Faces.ListTests
{
    public class FaceShould
    {
        private static readonly Guid ValidId = Guid.NewGuid();
        private const string ValidName = "Highway Billboard";
        private const decimal ValidRatePerDay = 123.45m;

        [Fact]
        public void BeCreatedSuccessfully()
        {
            var face = CreateFace();

            Assert.NotNull(face);
        }

        [Fact]
        public void SetTheId()
        {
            var expectedId = Guid.NewGuid();

            var face = CreateFace(id: expectedId);

            Assert.Equal(expectedId, face.Id);
        }

        [Fact]
        public void SetTheName()
        {
            const string expectedName = "Expected Face Name";

            var face = CreateFace(name: expectedName);

            Assert.Equal(expectedName, face.Name);
        }

        [Fact]
        public void SetTheRatePerDay()
        {
            const decimal expectedRate = 666.78m;

            var face = CreateFace(ratePerDay: expectedRate);

            Assert.Equal(expectedRate, face.RatePerDay);
        }

        [Fact]
        public void FailWhenTheIdIsEmpty()
        {
            var invalidId = Guid.Empty;

            Assert.Throws<ArgumentException>(
                () => CreateFace(id: invalidId));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void FailWhenTheNameIsInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(
                () => new Face(ValidId, invalidName, ValidRatePerDay));
        }

        [Fact]
        public void FailWhenTheRateIsNegative()
        {
            const decimal negativeRate = -0.10m;

            Assert.Throws<ArgumentException>(
                () => CreateFace(ratePerDay: negativeRate));
        }

        private Face CreateFace(Guid? id = null, string? name = null, decimal? ratePerDay = null)
        {
            return new Face(
                id ?? ValidId,
                name ?? ValidName,
                ratePerDay ?? ValidRatePerDay);
        }
    }
}