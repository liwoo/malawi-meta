using ErrorOr;
using FluentAssertions;
using MalawiMeta.Api.Domain.District;
using MalawiMeta.Api.Domain.Shared.ValueObjects;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.UseCases.Districts;
using Microsoft.AspNetCore.Http;
using Moq;

namespace MalawiMeta.Test.Unit.UseCases.Districts;

public class FetchAllDistrictsUseCaseTest
{

    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsError_ReturnsError()
    {
        // Arrange
        var expectedError = Error.Validation(StatusCodes.Status404NotFound.ToString(), "Districts not found");
        var mockDistrictService = new Mock<IDistrictService>();
        mockDistrictService.Setup(s => s.GetDistrictsAsync()).ReturnsAsync(expectedError);
        var useCase = new FetchAllDistrictsUseCase(mockDistrictService.Object);
        
        // Act
        var result = await useCase.ExecuteAsync(null);
        
        // Assert
        result.IsError.Should().BeTrue();
        result.FirstError.Should().BeEquivalentTo(expectedError);
    }
    
    [Fact]
    public async Task ExecuteAsync_WhenDistrictServiceReturnsDistricts_ReturnsDistricts()
    {
        // Arrange
        var district1 = District.Create("district1", "DT", new RegionId(Guid.NewGuid()));
        
        //create an IEnumerable<District> from the above district
        IEnumerable<District> expectedDistricts = new List<District> {district1};
        
        var mockDistrictService = new Mock<IDistrictService>();
        
        var expectedErrorOrDistricts = ErrorOrFactory.From(expectedDistricts);
        mockDistrictService.Setup(s => s.GetDistrictsAsync()).ReturnsAsync(expectedErrorOrDistricts);
        var useCase = new FetchAllDistrictsUseCase(mockDistrictService.Object);
        
        // Act
        var result = await useCase.ExecuteAsync(null);
        
        // Assert
        result.IsError.Should().BeFalse();
        result.Value.Count().Should().Be(1);
        result.Value.First().District.Should().Be(district1.Name);
    }
}