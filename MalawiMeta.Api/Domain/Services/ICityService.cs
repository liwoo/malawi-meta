using ErrorOr;
using MalawiMeta.Api.Domain.Aggregates;

namespace MalawiMeta.Api.Domain.Services;

public interface ICityService
{
    public Task<ErrorOr<IEnumerable<City>>> GetCitiesAsync();
    public Task<ErrorOr<City>> GetCityByIdAsync(Guid id);
    Task<ErrorOr<City>> AddCityAsync(City city);
    Task<ErrorOr<City>> UpdateCityAsync(City city);
    Task<ErrorOr<bool>> DeleteCityAsync(Guid id);
}
