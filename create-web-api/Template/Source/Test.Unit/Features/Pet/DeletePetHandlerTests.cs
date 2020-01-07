using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class DeletePetHandlerTests : TestBase
    {
        public DeletePetHandlerTests()
        {
            _uut = new DeletePet.Handler(Context);
        }

        private readonly DeletePet.Handler _uut;

        [Fact]
        public async Task ShouldReturnUpdatedPet_WhenCommandIsValid()
        {
            // Arrange
            var pet = await Context.SeedPetAsync();
            var command = new DeletePet.Command { Id = pet.Id };

            // Act
            await _uut.Handle(command, CancellationToken.None);

            // Assert
            var expectedToBeNull = Context.Pets.FirstOrDefault(p => p.Id == pet.Id);
            expectedToBeNull.Should().BeNull();
        }
    }
}
