using ErrorOr;
using FluentAssertions;
using MalawiMeta.Api.Domain.Aggregates;
using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Api.UseCases.Cities;
using Microsoft.AspNetCore.Http;
using Moq;

namespace MalawiMeta.Test.Unit.UseCases.Cities;
public class FetchCityByIdUseCaseTest
{
    [Fact]
    public async Task ExecuteAsync_Success_ReturnsCityResponseDto()
    {
        // Arrange
        var cityId = Guid.NewGuid().ToString();
        var city = City.Create("City1", Guid.NewGuid(), 10.0, 20.0);
        var expectedCityResponse = new CityResponseDto(
            city.Name,
            city.DistrictId.ToString(),
            new GeolocationDto(city.Geolocation.Latitude, city.Geolocation.Longitude)
        );

        var cityServiceMock = new Mock<ICityService>();
        cityServiceMock.Setup(s => s.GetCityByIdAsync(city.Id)).ReturnsAsync(ErrorOrFactory.From(city));
        var fetchCityByIdUseCase = new FetchCityByIdUseCase(cityServiceMock.Object);

        // Act
        var result = await fetchCityByIdUseCase.ExecuteAsync(new FetchCityByIdCaseArgs(cityId));

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().NotBeNull();
        result.Value.Should().BeEquivalentTo(expectedCityResponse);
    }

    [Fact]
    public async Task ExecuteAsync_InvalidId_ReturnsValidationError()
    {
        // Arrange
        var invalidCityId = "invalid-id";
        var cityServiceMock = new Mock<ICityService>();
        var fetchCityByIdUseCase = new FetchCityByIdUseCase(cityServiceMock.Object);

        // Act
        var result = await fetchCityByIdUseCase.ExecuteAsync(new FetchCityByIdCaseArgs(invalidCityId));

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(Error.Validation(StatusCodes.Status400BadRequest.ToString(), "ID is not a valid GUID"));
    }

    [Fact]
    public async Task ExecuteAsync_CityServiceError_ReturnsCityServiceError()
    {
        // Arrange
        var cityId = Guid.NewGuid().ToString();
        var expectedError = Error.Validation(StatusCodes.Status404NotFound.ToString(), "City not found");
        var cityServiceMock = new Mock<ICityService>();
        cityServiceMock.Setup(s => s.GetCityByIdAsync(It.IsAny<Guid>())).ReturnsAsync(expectedError);
        var fetchCityByIdUseCase = new FetchCityByIdUseCase(cityServiceMock.Object);

        // Act
        var result = await fetchCityByIdUseCase.ExecuteAsync(new FetchCityByIdCaseArgs(cityId));

        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(expectedError);
    }
}
