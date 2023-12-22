using ErrorOr;
using FluentAssertions;
using MalawiMeta.Api.Domain.District;
using MalawiMeta.Api.Domain.Shared.ValueObjects;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.UseCases.Districts;
using Microsoft.AspNetCore.Http;
using Moq;

namespace MalawiMeta.Test.Unit.UseCases.Districts;

public class FetchDistrictsByCodeUseCaseTest
{
    [Fact]
    public async Task ExecuteAsync_WhenCodeIsNull_ReturnsValidationError()
    {
        // Arrange
        var expectedError = Error.Validation();
        var mockDistrictService = new Mock<IDistrictRepository>();
        mockDistrictService.Setup(s => s.GetDistrictByCodeAsync(null)).ReturnsAsync(expectedError);
        var useCase = new FetchDistrictByCodeUseCase(mockDistrictService.Object);

        // Act
        var result = await useCase.ExecuteAsync(null);

        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(expectedError);
    }

    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsDistricts_ReturnsDistrict()
    {
        // Arrange
        var district1 = District.Create(Guid.Parse("0a8d99ac-e161-459e-a719-76992b72e8c2"), "district1", "DT", new RegionId(Guid.NewGuid()));

        //create an IEnumerable<District> from the above district
        IEnumerable<District> expectedDistricts = new List<District> { district1 };

        var mockDistrictService = new Mock<IDistrictRepository>();

        var expectedErrorOrDistricts = ErrorOrFactory.From(expectedDistricts);
        mockDistrictService.Setup(s => s.GetDistrictByCodeAsync()).ReturnsAsync(expectedErrorOrDistricts);
        var useCase = new FetchAllDistrictsUseCase(mockDistrictService.Object);

        // Act
        var result = await useCase.ExecuteAsync(null);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Count().Should().Be(1);
        result.Value.First().District.Should().Be(district1.Name);
    }

    [Fact]
    public async Task ExecuteAsync_WhenCodeIsLowerCase_ReturnsDistrict()
    {
        // Arrange
        var district1 = District.Create(Guid.Parse("0a8d99ac-e161-459e-a719-76992b72e8c2"), "district1", "DT", new RegionId(Guid.NewGuid()));

        //create an IEnumerable<District> from the above district
        IEnumerable<District> expectedDistricts = new List<District> { district1 };

        var mockDistrictService = new Mock<IDistrictRepository>();

        var expectedErrorOrDistricts = ErrorOrFactory.From(expectedDistricts);
        mockDistrictService.Setup(s => s.GetDistrictByCodeAsync("dt"));
        var useCase = new FetchDistrictByCodeUseCase(mockDistrictService.Object);

        // Act
        var result = await useCase.ExecuteAsync(null);

        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Should().Be(1);
        result.Value.District.Should().Be(district1.Code);
    }

    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsValidationError_ReturnsNotFoundError()
    {
        // Arrange
        var expectedError = Error.Validation(StatusCodes.Status404NotFound.ToString(), "District not found");
        var mockDistrictService = new Mock<IDistrictRepository>();
        mockDistrictService.Setup(s => s.GetDistrictByCodeAsync(null)).ReturnsAsync(expectedError);
        var useCase = new FetchDistrictByCodeUseCase(mockDistrictService.Object);

        // Act
        var result = await useCase.ExecuteAsync(null);

        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(expectedError);
    }

    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsDistricts_ReturnsDistrictWithRegionCodeValue()
    {
        // Arrange
        var regionId = Guid.NewGuid();
        var district1 = District.Create(Guid.Parse("0a8d99ac-e161-459e-a719-76992b72e8c2"), "district1", "DT", new RegionId(regionId));
        
        //create an IEnumerable<District> from the above district
        IEnumerable<District> expectedDistricts = new List<District> {district1};
        
        var mockDistrictService = new Mock<IDistrictRepository>();
        
        var expectedErrorOrDistricts = ErrorOrFactory.From(expectedDistricts);
        mockDistrictService.Setup(s => s.GetDistrictsAsync()).ReturnsAsync(expectedErrorOrDistricts);
        var useCase = new FetchAllDistrictsUseCase(mockDistrictService.Object);
        
        // Act
        var result = await useCase.ExecuteAsync(null);
        
        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Count().Should().Be(1);
        result.Value.First().RegionId.Should().Be(regionId.ToString());
    }

    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsDistrictByCode_ReturnsError()
    {
        // Arrange
        var regionId = Guid.NewGuid();
        var district1 = District.Create(Guid.Parse("0a8d99ac-e161-459e-a719-76992b72e8c2"), "district1", "DT", new RegionId(regionId));

        //create an IEnumerable<District> from the above district
        IEnumerable<District> expectedDistricts = new List<District> { district1 };

        var mockDistrictService = new Mock<IDistrictRepository>();

        var expectedErrorOrDistricts = ErrorOrFactory.From(expectedDistricts);
        mockDistrictService.Setup(s => s.GetDistrictsAsync()).ReturnsAsync(expectedErrorOrDistricts);
        var useCase = new FetchDistrictByCodeUseCase(mockDistrictService.Object);

        // Act
        var result = await useCase.ExecuteAsync(null);

        // Assert
        result.IsError.Should().BeTrue();
        result.Value.Should().Be(null);
    }

    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsDistrictByCode_ReturnsDistrictWithCodeValue()
    {
        // Arrange
        var regionId = Guid.NewGuid();
        var district1 = District.Create(Guid.Parse("0a8d99ac-e161-459e-a719-76992b72e8c2"), "district1", "DT", new RegionId(regionId));

        //create an IEnumerable<District> from the above district
        IEnumerable<District> expectedDistricts = new List<District> { district1 };

        var mockDistrictService = new Mock<IDistrictRepository>();

        var expectedErrorOrDistricts = ErrorOrFactory.From(expectedDistricts);
        mockDistrictService.Setup(s => s.GetDistrictsAsync()).ReturnsAsync(expectedErrorOrDistricts);
        var useCase = new FetchDistrictByCodeUseCase(mockDistrictService.Object);

        // Act
        var result = await useCase.ExecuteAsync(null);

        // Assert
        result.IsError.Should().BeTrue();
        result.Value.Should().Be(1);
        result.Value.Code.Should().Be(district1.Code);
    }

}