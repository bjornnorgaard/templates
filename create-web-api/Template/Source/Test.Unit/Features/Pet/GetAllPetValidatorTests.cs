using Application.Features.Pet;
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class GetAllPetValidatorTests : TestBase
    {
        private readonly GetAllPet.Validator _uut;

        public GetAllPetValidatorTests()
        {
            _uut = new GetAllPet.Validator();
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ShouldHaveValidationError_WhenNameIsInvalid(int take)
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldHaveValidationErrorFor(e => e.Take, take);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        public void ShouldNotHaveValidationError_WhenNameValid(int take)
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldNotHaveValidationErrorFor(e => e.Take, take);
        }
    }
}
