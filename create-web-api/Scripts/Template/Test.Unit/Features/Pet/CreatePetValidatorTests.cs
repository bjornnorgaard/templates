using Application.Features.[Entity];
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Create[Entity]ValidatorTests : TestBase
    {
        private readonly Create[Entity].Validator _uut;

        public Create[Entity]ValidatorTests()
        {
            _uut = new Create[Entity].Validator();
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
