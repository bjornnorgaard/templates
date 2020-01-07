using System.Threading;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Get[Entity]HandlerTests : TestBase
    {
        public Get[Entity]HandlerTests()
        {
            _uut = new Get[Entity].Handler(Context);
        }

        private readonly Get[Entity].Handler _uut;

        [Fact]
        public async Task ShouldReturn[Entity]_WhenCommandIsValid()
        {
            // Arrange
            var [Entity.ToLower] = await Context.Seed[Entity]Async();
            var command = new Get[Entity].Command { Id = [Entity.ToLower].Id };

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.[Entity].Should().BeEquivalentTo([Entity.ToLower]);
        }
    }
}
