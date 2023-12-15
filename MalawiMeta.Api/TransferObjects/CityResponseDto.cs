namespace MalawiMeta.Api.TransferObjects;

public sealed record CityResponseDto(
    string Name,
    string DistrictId,
    GeolocationDto Geolocation
);