using ErrorOr;
using MalawiMeta.Api.Domain.Aggregates;

namespace MalawiMeta.Api.Domain.Services;

public class InMemoryCityService : ICityService
{
    private readonly IEnumerable<City> _cities;

    public InMemoryCityService()
    {
        IEnumerable<City> initialCity = new[]
        {
            City.Create("Blantyre", Guid.NewGuid()),
            City.Create("Zomba", Guid.NewGuid()),
            City.Create("Mangochi", Guid.NewGuid()),
            City.Create("Lilongwe", Guid.NewGuid()),
            City.Create("Mzuzu", Guid.NewGuid()),
        };
        _cities = initialCity;
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

