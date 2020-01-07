using System;
using Application.Features.Pet;
using AutoMapper;
using FluentAssertions;
using Xunit;

namespace Test.Unit.Features.Pet
{
    public class MappingProfileTests : TestBase
    {
        [Fact]
        public void ShouldMapCommandToPet_WhenMapIsConfigured()
        {
            // Arrange
            var expectation = new Models.Pet { Id = Guid.Empty, Age = 20, Name = "Kitty" };
            var command = new CreatePet.Command { Age = expectation.Age, Name = expectation.Name };

            // Act
            var result = Mapper.Map<Models.Pet>(command);

            // Assert
            result.Should().BeEquivalentTo(expectation);
        }

        [Fact]
        public void ShouldNotThrowConfigurationException_WhenMapIsConfigured()
        {
            // Arrange
            var configuration = Mapper.ConfigurationProvider;

            // Act
            Action act = () => configuration.AssertConfigurationIsValid();

            // Assert
            act.Should().NotThrow<AutoMapperConfigurationException>();
        }
    }
}
