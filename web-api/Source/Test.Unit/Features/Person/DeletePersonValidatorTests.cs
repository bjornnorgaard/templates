using System;
using Application.Features.Person;
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.Person
{
    public class DeletePersonValidatorTests : TestBase
    {
        private readonly DeletePerson.Validator _uut;

        public DeletePersonValidatorTests()
        {
            _uut = new DeletePerson.Validator();
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


