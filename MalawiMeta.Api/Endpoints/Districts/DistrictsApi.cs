namespace MalawiMeta.Api.Endpoints.Districts;

public static partial class DistrictEndpoints
{
    public static void MapDistricts(this WebApplication app)
    {
        app.MapGroup("/api/districts")
            .MapDistrictsApi()
            .WithTags("Districts");
    }

    private static RouteGroupBuilder MapDistrictsApi(this RouteGroupBuilder group)
    {
        group.MapAllDistrictsEndpoint();
        group.MapDistrictByIdEndpoint();
        group.MapDistrictByCodeEndpoint();
        return group;
    }
}
