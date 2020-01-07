using System;
using Application.Features.Pet;
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class DeletePetValidatorTests : TestBase
    {
        private readonly DeletePet.Validator _uut;

        public DeletePetValidatorTests()
        {
            _uut = new DeletePet.Validator();
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
