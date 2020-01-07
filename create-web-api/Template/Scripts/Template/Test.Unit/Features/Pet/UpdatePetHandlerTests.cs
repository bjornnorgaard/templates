using System.Threading;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Update[Entity]HandlerTests : TestBase
    {
        public Update[Entity]HandlerTests()
        {
            _uut = new Update[Entity].Handler(Context, Mapper);
        }

        private readonly Update[Entity].Handler _uut;

        [Fact]
        public async Task ShouldReturnUpdated[Entity]_WhenCommandIsValid()
        {
            // Arrange
            var [Entity.ToLower] = await Context.Seed[Entity]Async();
            var command = new Update[Entity].Command().Valid([Entity.ToLower].Id);

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.[Entity].Should().BeEquivalentTo(command);
        }
    }
}
