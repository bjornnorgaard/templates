using System;
using Application.Features.Pet;
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class GetPetValidatorTests : TestBase
    {
        private readonly GetPet.Validator _uut;

        public GetPetValidatorTests()
        {
            _uut = new GetPet.Validator();
        }

        [Fact]
        public void ShouldHaveValidationError_WhenNameIsInvalid()
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldHaveValidationErrorFor(e => e.Id, Guid.Empty);
        }

        [Fact]
        public void ShouldNotHaveValidationError_WhenNameValid()
        {
            // Arrange

            // Act

            // Assert
            _uut.ShouldNotHaveValidationErrorFor(e => e.Id, Guid.NewGuid());
        }
    }
}
