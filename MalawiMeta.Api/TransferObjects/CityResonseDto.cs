﻿namespace MalawiMeta.Api.TransferObjects;

public sealed record CityResponseDto(
    string City,
    string DistrictId,
    GeolocationDto Geolocation
);

public sealed record GeolocationDto(
    double Latitude,
    double Longitude
);