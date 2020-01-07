using Application.Features.Pet;
using FluentAssertions;
using Infrastructure.HttpExtensions;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Arrange.Features.Pet;
using Xunit;

namespace Test.Integration.Features.Pet
{
    public class GetAllPetTests : TestBase
    {
        [Fact]
        public async Task ShouldReturnList_WhenRequestIsValid()
        {
            // Arrange

            // Act
            var result = await Client.GetAsync("api/v1/pet");

            var content = await result.Content.ReadAsAsync<GetAllPet.Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.Should().BeOfType<GetAllPet.Result>();
        }

        [Fact]
        public async Task ShouldReturnBadRequest_WhenTakeIs0()
        {
            // Arrange

            // Act
            var result = await Client.GetAsync("api/v1/pet?take=0");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Theory]
        [InlineData(10, 0, 10)]
        [InlineData(10, 5, 5)]
        [InlineData(10, 9, 1)]
        [InlineData(10, 10, 0)]
        public async Task ShouldReturnOne_WhenTakeIs1AndSkipIs1(int take, int skip, int expectedCount)
        {
            // Arrange
            var pets = new List<Models.Pet>();
            for (var i = 0; i < 10; i++)
            {
                pets.Add((await Mediator.Send(new CreatePet.Command().Valid())).Pet);
            }

            // Act
            var result = await Client.GetAsync($"api/v1/pet?take={take}&skip={skip}");
            var content = await result.Content.ReadAsAsync<GetAllPet.Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.Pets.Count().Should().Be(expectedCount);
        }
    }
}
