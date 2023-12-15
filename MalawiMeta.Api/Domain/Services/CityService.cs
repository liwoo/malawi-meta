using ErrorOr;
using MalawiMeta.Api.Domain.Aggregates;

namespace MalawiMeta.Api.Domain.Services;
public class InMemoryCityService : ICityService
{
    private readonly IEnumerable<City> _cities;
    public InMemoryCityService()
    {
        IEnumerable<City> initialCities = new[]
        {
            City.Create("Blantyre", Guid.NewGuid(), -15.786111, 35.005833),
            City.Create("Zomba", Guid.NewGuid(), -15.3925, 35.3133),
            City.Create("Mangochi", Guid.NewGuid(), -14.478333, 35.264722),
            City.Create("Lilongwe", Guid.NewGuid(), -13.966667, 33.783333),
            City.Create("Mzuzu", Guid.NewGuid(), -11.465556, 34.020882),
        };
        _cities = initialCities;
    }
    public Task<ErrorOr<IEnumerable<City>>> GetCitiesAsync()
    {
        return Task.FromResult(ErrorOrFactory.From(_cities));
    }
    public Task<ErrorOr<City>> GetCityByIdAsync(Guid id)
    {
        var city = _cities.FirstOrDefault(d => d.Id == id);

        if (city == null)
        {
            return Task.FromResult<ErrorOr<City>>(Error.NotFound(StatusCodes.Status404NotFound.ToString(), "City not found"));
        }
        return Task.FromResult<ErrorOr<City>>(city);
    }
    public Task<ErrorOr<City>> AddCityAsync(City city)
    {
        throw new NotImplementedException();
    }
    public Task<ErrorOr<City>> UpdateCityAsync(City city)
    {
        throw new NotImplementedException();
    }
    public Task<ErrorOr<bool>> DeleteCityAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}

