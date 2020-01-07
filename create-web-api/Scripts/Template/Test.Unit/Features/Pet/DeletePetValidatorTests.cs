using System;
using Application.Features.[Entity];
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Delete[Entity]ValidatorTests : TestBase
    {
        private readonly Delete[Entity].Validator _uut;

        public Delete[Entity]ValidatorTests()
        {
            _uut = new Delete[Entity].Validator();
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
