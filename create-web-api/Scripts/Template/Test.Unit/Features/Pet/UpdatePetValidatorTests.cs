using System;
using Application.Features.[Entity];
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Update[Entity]ValidatorTests : TestBase
    {
        private readonly Update[Entity].Validator _uut;

        public Update[Entity]ValidatorTests()
        {
            _uut = new Update[Entity].Validator();
        }

        [Fact]
        public void ShouldHaveValidationError_WhenNameIsInvalid()
        {
            // Arrange

            // Act

            // Assert
            // TODO: Validate command properties.
            throw new NotImplementedException();
        }
    }
}
