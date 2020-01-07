using System;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Infrastructure.HttpExtensions;
using Microsoft.AspNetCore.Http;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Integration.Features.[Entity]
{
    public class Get[Entity]Tests : TestBase
    {
        [Fact]
        public async Task ShouldReturn404_WhenIdIsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();

            // Act
            var result = await Client.GetAsync($"api/v1/[Entity.ToLower]/{id}");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturn[Entity]AndOk_WhenExistsWithId()
        {
            // Arrange
            var expectation = (await Mediator.Send(new Create[Entity].Command().Valid())).[Entity];

            // Act
            var result = await Client.GetAsync($"api/v1/[Entity.ToLower]/{expectation.Id}");
            var content = await result.Content.ReadAsAsync<Get[Entity].Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.[Entity].Should().BeEquivalentTo(expectation);
        }
    }
}
