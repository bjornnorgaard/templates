using System;
using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Integration.Features.[Entity]
{
    public class Delete[Entity]Tests : TestBase
    {
        [Fact]
        public async Task ShouldReturnNotFound_WhenIdIsNotFound()
        {
            // Arrange
            var id = Guid.NewGuid().ToString();

            // Act
            var result = await Client.DeleteAsync($"api/v1/[Entity.ToLower]/{id}");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public async Task ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var [Entity.ToLower] = (await Mediator.Send(new Create[Entity].Command().Valid())).[Entity];

            // Act
            var result = await Client.DeleteAsync($"api/v1/[Entity.ToLower]/{[Entity.ToLower].Id}");

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
