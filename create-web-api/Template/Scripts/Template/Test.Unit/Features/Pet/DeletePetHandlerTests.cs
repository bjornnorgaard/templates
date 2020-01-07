using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class Delete[Entity]HandlerTests : TestBase
    {
        public Delete[Entity]HandlerTests()
        {
            _uut = new Delete[Entity].Handler(Context);
        }

        private readonly Delete[Entity].Handler _uut;

        [Fact]
        public async Task ShouldReturnUpdated[Entity]_WhenCommandIsValid()
        {
            // Arrange
            var [Entity.ToLower] = await Context.Seed[Entity]Async();
            var command = new Delete[Entity].Command { Id = [Entity.ToLower].Id };

            // Act
            await _uut.Handle(command, CancellationToken.None);

            // Assert
            var expectedToBeNull = Context.[Entity]s.FirstOrDefault(p => p.Id == [Entity.ToLower].Id);
            expectedToBeNull.Should().BeNull();
        }
    }
}
