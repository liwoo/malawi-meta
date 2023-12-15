using ErrorOr;
using FluentAssertions;
using MalawiMeta.Api.Domain.Aggregates;
using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.UseCases.Cities;
using Microsoft.AspNetCore.Http;
using Moq;

namespace MalawiMeta.Test.Unit.UseCases.Cities;
public class FetchAllCitiesUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_Success_ReturnsCityResponseList()
    {
        // Arrange
        var city1 = City.Create("City1", Guid.NewGuid(), 10.0, 20.0);
        var city2 = City.Create("City2", Guid.NewGuid(), 30.0, 40.0);

        IEnumerable<City> expectedCities = new List<City> {city1, city2};

        var cityServiceMock = new Mock<ICityService>();

        var expectedErrorOrCities = ErrorOrFactory.From(expectedCities);
        cityServiceMock.Setup(s => s.GetCitiesAsync()).ReturnsAsync(expectedErrorOrCities);
        var useCase = new FetchAllCitiesUseCase(cityServiceMock.Object);

        var fetchAllCitiesUseCase = new FetchAllCitiesUseCase(cityServiceMock.Object);

        // Act
        var result = await fetchAllCitiesUseCase.ExecuteAsync(null);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        var cityResponseList = result.Value.ToList();
        cityResponseList.Should().HaveCount(2);
        // Assert properties for City1
        cityResponseList[0].Name.Should().Be("City1");
        cityResponseList[0].DistrictId.Should().Be(city1.DistrictId.ToString());
        cityResponseList[0].Geolocation.Latitude.Should().Be(10.0);
        cityResponseList[0].Geolocation.Longitude.Should().Be(20.0);
        // Assert properties for City2
        cityResponseList[1].Name.Should().Be("City2");
        cityResponseList[1].DistrictId.Should().Be(city2.DistrictId.ToString());
        cityResponseList[1].Geolocation.Latitude.Should().Be(30.0);
        cityResponseList[1].Geolocation.Longitude.Should().Be(40.0);
    }

    [Fact]
    public async Task ExecuteAsync_Error_ReturnsFirstError()
    {
       // Arrange
        var expectedError = Error.Validation(StatusCodes.Status404NotFound.ToString(), "Cities not found");
        var cityServiceMock = new Mock<ICityService>();
        cityServiceMock.Setup(s => s.GetCitiesAsync()).ReturnsAsync(expectedError);
        var useCase = new FetchAllCitiesUseCase(cityServiceMock.Object);
        
        // Act
        var result = await useCase.ExecuteAsync(null);
        
        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(expectedError);
    }
}


       