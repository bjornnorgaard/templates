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
    public class Update[Entity]Tests : TestBase
    {
        [Fact]
        public async Task ShouldReturnBadRequest_WhenAgeIsMissing()
        {
            // Arrange
            var command = new Update[Entity].Command().Invalid(Guid.NewGuid());

            // Act
            var result = await Client.PutAsJsonAsync($"api/v1/[Entity.ToLower]/{command.Id}", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task ShouldReturnNotFound_WhenIdIdNotFound()
        {
            // Arrange
            var command = new Update[Entity].Command().Valid(Guid.NewGuid());

            // Act
            var result = await Client.PutAsJsonAsync($"api/v1/[Entity.ToLower]/{command.Id}", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var [Entity.ToLower] = (await Mediator.Send(new Create[Entity].Command().Valid())).[Entity];
            var command = new Update[Entity].Command().Valid([Entity.ToLower].Id);

            // Act
            var result = await Client.PutAsJsonAsync($"api/v1/[Entity.ToLower]/{command.Id}", command);
            var content = await result.Content.ReadAsAsync<Update[Entity].Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.[Entity].Should().BeEquivalentTo(command);
        }
    }
}
