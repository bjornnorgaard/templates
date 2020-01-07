using Application.Features.Pet;
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class CreatePetValidatorTests : TestBase
    {
        private readonly CreatePet.Validator _uut;

        public CreatePetValidatorTests()
        {
            _uut = new CreatePet.Validator();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ShouldHaveValidationError_WhenNameIsInvalid(string name)
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldHaveValidationErrorFor(e => e.Name, name);
        }

        [Theory]
        [InlineData("Kitty")]
        [InlineData("K")]
        public void ShouldNotHaveValidationError_WhenNameValid(string name)
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldNotHaveValidationErrorFor(e => e.Name, name);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void ShouldHaveValidationError_WhenAgeIsInvalid(int age)
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldHaveValidationErrorFor(e => e.Age, age);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ShouldNotHaveValidationError_WhenAgeIsValid(int age)
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldNotHaveValidationErrorFor(e => e.Age, age);
        }
    }
}
