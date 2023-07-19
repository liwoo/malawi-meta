﻿using MalawiMeta.Api.Domain.Services;
using MalawiMeta.Api.Endpoints.Districts;
using MalawiMeta.Api.UseCases.Districts;
using MalawiMeta.Api.Endpoints.Cities;
using MalawiMeta.Api.UseCases.Cities;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

// app registrations
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var openApiSection = builder.Configuration.GetSection("OpenApi");
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = openApiSection["Version"] ?? "v1",
        Title = openApiSection["Name"] ?? "Malawi Meta API",
        Description = openApiSection["Description"] ?? "A simple API to retrieve Malawi's districts and regions.",
    });
});

builder.Services.AddScoped<IDistrictService, InMemoryDistrictService>();
builder.Services.AddScoped<IFetchAllDistrictsUseCase, FetchAllDistrictsUseCase>();
builder.Services.AddScoped<IFetchDistrictByIdUseCase, FetchDistrictByIdUseCase>();

builder.Services.AddScoped<ICityService, InMemoryCityService>();
builder.Services.AddScoped<IFetchAllCitiesUseCase, FetchAllCitiesUseCase>();
builder.Services.AddScoped<IFetchCityByIdUseCase, FetchCityByIdUseCase>();

var app = builder.Build();
/*---------------------------------*/
// middleware registrations
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    //change swagger endpoint to "/" instead of "/swagger"
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Malawi Meta API");
    c.RoutePrefix = string.Empty;
});

/*---------------------------------*/
// endpoint registrations
app.MapDistricts();
app.MapCities();

app.Run();

public partial class Program { }
