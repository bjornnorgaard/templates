using System.Threading;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class UpdatePetHandlerTests : TestBase
    {
        public UpdatePetHandlerTests()
        {
            _uut = new UpdatePet.Handler(Context, Mapper);
        }

        private readonly UpdatePet.Handler _uut;

        [Fact]
        public async Task ShouldReturnUpdatedPet_WhenCommandIsValid()
        {
            // Arrange
            var pet = await Context.SeedPetAsync();
            var command = new UpdatePet.Command().Valid(pet.Id);

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.Pet.Should().BeEquivalentTo(command);
        }
    }
}
