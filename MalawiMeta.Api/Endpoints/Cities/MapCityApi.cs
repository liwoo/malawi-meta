namespace MalawiMeta.Api.Endpoints.Cities;
public static partial class CityEndpoints
{
    public static void MapCities(this WebApplication app)
    {
        app.MapGroup("/api/cities")
            .MapCitiesApi()
            .WithTags("Cities");
    }

    private static RouteGroupBuilder MapCitiesApi(this RouteGroupBuilder group)
    {
        group.MapAllCities();
        group.MapCityById();
        return group;
    }
}
