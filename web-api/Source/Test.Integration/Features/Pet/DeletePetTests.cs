using System;
using System.Threading.Tasks;
using Application.Features.Pet;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Integration.Features.Pet
{
    public class DeletePetTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnNotFound_WhenIdIsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();

            // Act
            var result = await Client.DeleteAsync($"api/v1/pet/{id}");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var pet = (await Mediator.Send(new CreatePet.Command().Valid())).Pet;

            // Act
            var result = await Client.DeleteAsync($"api/v1/pet/{pet.Id}");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
