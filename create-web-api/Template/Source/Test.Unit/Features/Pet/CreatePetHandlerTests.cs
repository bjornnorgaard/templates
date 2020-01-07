using System.Threading;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class CreatePetHandlerTests : TestBase
    {
        public CreatePetHandlerTests()
        {
            _uut = new CreatePet.Handler(Context, Mapper);
        }

        private readonly CreatePet.Handler _uut;

        [Fact]
        public async Task ShouldReturnPet_WhenCommandIsValid()
        {
            // Arrange
            var command = new CreatePet.Command().Valid();

            // Act
            var result = await _uut.Handle(command, CancellationToken.None);

            // Assert
            result.Pet.Age.Should().Be(command.Age);
            result.Pet.Name.Should().Be(command.Name);
            result.Pet.Id.Should().NotBeEmpty();
        }
    }
}
