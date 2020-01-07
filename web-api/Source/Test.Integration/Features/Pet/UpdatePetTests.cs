using System;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Infrastructure.HttpExtensions;
using Microsoft.AspNetCore.Http;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Integration.Features.Pet
{
    public class UpdatePetTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnBadRequest_WhenAgeIsMissing()
        {
            // Arrange
            var command = new UpdatePet.Command().Invalid(Guid.NewGuid());

            // Act
            var result = await Client.PutAsJsonAsync($"api/v1/pet/{command.Id}", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task ShouldReturnNotFound_WhenIdIdNotFound()
        {
            // Arrange
            var command = new UpdatePet.Command().Valid(Guid.NewGuid());

            // Act
            var result = await Client.PutAsJsonAsync($"api/v1/pet/{command.Id}", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var pet = (await Mediator.Send(new CreatePet.Command().Valid())).Pet;
            var command = new UpdatePet.Command().Valid(pet.Id);

            // Act
            var result = await Client.PutAsJsonAsync($"api/v1/pet/{command.Id}", command);
            var content = await result.Content.ReadAsAsync<UpdatePet.Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.Pet.Should().BeEquivalentTo(command);
        }
    }
}
