using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class GetAllPetHandlerTests : TestBase
    {
        public GetAllPetHandlerTests()
        {
            _uut = new GetAllPet.Handler(Context);
        }

        private readonly GetAllPet.Handler _uut;

        [Fact]
        public async Task ShouldReturnPet_WhenCommandIsValid()
        {
            // Arrange
            var pet = await Context.SeedPetAsync();
            var command = new GetAllPet.Command();

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.Pets.Count().Should().Be(1);
            result.Pets.FirstOrDefault().Should().BeEquivalentTo(pet);
        }
    }
}
