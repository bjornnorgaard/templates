using System;
using Application.Features.[Entity];
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Get[Entity]ValidatorTests : TestBase
    {
        private readonly Get[Entity].Validator _uut;

        public Get[Entity]ValidatorTests()
        {
            _uut = new Get[Entity].Validator();
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
