using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Infrastructure.HttpExtensions;
using Microsoft.AspNetCore.Http;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Integration.Features.Pet
{
    public class CreatePetTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnBadRequest_WhenAgeIsMissing()
        {
            // Arrange
            var command = new CreatePet.Command().Invalid();

            // Act
            var result = await Client.PostAsJsonAsync("api/v1/pet", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var command = new CreatePet.Command().Valid();

            // Act
            var result = await Client.PostAsJsonAsync("api/v1/pet", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
