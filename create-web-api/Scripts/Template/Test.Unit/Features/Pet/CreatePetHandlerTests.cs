using System.Threading;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Create[Entity]HandlerTests : TestBase
    {
        public Create[Entity]HandlerTests()
        {
            _uut = new Create[Entity].Handler(Context, Mapper);
        }

        private readonly Create[Entity].Handler _uut;

        [Fact]
        public async Task ShouldReturn[Entity]_WhenCommandIsValid()
        {
            // Arrange
            var command = new Create[Entity].Command().Valid();

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.[Entity].Id.Should().NotBeEmpty();
        }
    }
}
