using System.Collections.Generic;
using Application.Features.[Entity];
using FluentAssertions;
using Infrastructure.HttpExtensions;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;
using Test.Arrange.Features.[Entity];
using Xunit;

namespace Test.Integration.Features.[Entity]
{
    public class GetAll[Entity]Tests : TestBase
    {
        [Fact]
        public async Task ShouldReturnList_WhenRequestIsValid()
        {
            // Arrange

            // Act
            var result = await Client.GetAsync("api/v1/[Entity.ToLower]");
            var content = await result.Content.ReadAsAsync<GetAll[Entity].Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.Should().BeOfType<GetAll[Entity].Result>();
        }

        [Fact]
        public async Task ShouldReturnBadRequest_WhenTakeIs0()
        {
            // Arrange

            // Act
            var result = await Client.GetAsync("api/v1/[Entity.ToLower]?take=0");

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
            var [Entity.ToLower]s = new List<Models.[Entity]>();
            for (var i = 0; i < 10; i++)
            {
                [Entity.ToLower]s.Add((await Mediator.Send(new Create[Entity].Command().Valid())).[Entity]);
            }

            // Act
            var result = await Client.GetAsync($"api/v1/[Entity.ToLower]?take={take}&skip={skip}");
            var content = await result.Content.ReadAsAsync<GetAll[Entity].Result>();

            // Assert
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            content.[Entity]s.Count().Should().Be(expectedCount);
        }
    }
}
