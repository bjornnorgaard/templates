using Application.Features.[Entity];
using FluentValidation.TestHelper;
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class GetAll[Entity]ValidatorTests : TestBase
    {
        private readonly GetAll[Entity].Validator _uut;

        public GetAll[Entity]ValidatorTests()
        {
            _uut = new GetAll[Entity].Validator();
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
