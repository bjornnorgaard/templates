using System.Threading.Tasks;
using Application.Features.[Entity];
using FluentAssertions;
using Infrastructure.HttpExtensions;
using Microsoft.AspNetCore.Http;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Integration.Features.[Entity]
{
    public class Create[Entity]Tests : TestBase
    {
        [Fact]
        public async Task ShouldReturnBadRequest_WhenAgeIsMissing()
        {
            // Arrange
            var command = new Create[Entity].Command().Invalid();

            // Act
            var result = await Client.PostAsJsonAsync("api/v1/[Entity.ToLower]", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status400BadRequest);
        }

        [Fact]
        public async Task ShouldReturnOk_WhenRequestIsValid()
        {
            // Arrange
            var command = new Create[Entity].Command().Valid();

            // Act
            var result = await Client.PostAsJsonAsync("api/v1/[Entity.ToLower]", command);

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
