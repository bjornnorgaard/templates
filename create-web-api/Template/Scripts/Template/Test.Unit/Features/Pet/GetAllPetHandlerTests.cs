using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Unit.Features.[Entity]
{
    public class GetAll[Entity]HandlerTests : TestBase
    {
        public GetAll[Entity]HandlerTests()
        {
            _uut = new GetAll[Entity].Handler(Context);
        }

        private readonly GetAll[Entity].Handler _uut;

        [Fact]
        public async Task ShouldReturn[Entity]_WhenCommandIsValid()
        {
            // Arrange
            var [Entity.ToLower] = await Context.Seed[Entity]Async();
            var command = new GetAll[Entity].Command();

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.[Entity]s.Count().Should().Be(1);
            result.[Entity]s.FirstOrDefault().Should().BeEquivalentTo([Entity.ToLower]);
        }
    }
}
