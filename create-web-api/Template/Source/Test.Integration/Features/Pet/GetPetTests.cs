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
    public class GetPetTests : TestBase
    {
        [Fact]
        public async Task ShouldReturn404_WhenIdIsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();

            // Act
            var result = await Client.GetAsync($"api/v1/pet/{id}");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturnPetAndOk_WhenExistsWithId()
        {
            // Arrange
            var expectation = (await Mediator.Send(new CreatePet.Command().Valid())).Pet;

            // Act
            var result = await Client.GetAsync($"api/v1/pet/{expectation.Id}");
            var content = await result.Content.ReadAsAsync<GetPet.Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.Pet.Should().BeEquivalentTo(expectation);
        }
    }
}
