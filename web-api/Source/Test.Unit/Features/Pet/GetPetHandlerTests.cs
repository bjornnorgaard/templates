using System.Threading;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class GetPetHandlerTests : TestBase
    {
        public GetPetHandlerTests()
        {
            _uut = new GetPet.Handler(Context);
        }

        private readonly GetPet.Handler _uut;

        [Fact]
        public async Task ShouldReturnPet_WhenCommandIsValid()
        {
            // Arrange
            var pet = await Context.SeedPetAsync();
            var command = new GetPet.Command { Id = pet.Id };

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.Pet.Should().BeEquivalentTo(pet);
        }
    }
}
