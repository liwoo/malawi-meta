using MalawiMeta.Api.Endpoints.Districts;
using MalawiMeta.Api.Exceptions;
using MalawiMeta.Api.Repositories;
using MalawiMeta.Api.UseCases.Districts;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);

// app registrations
builder.Services.AddExceptionHandler<DefaultExceptionHandler>();
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

builder.Services.AddScoped<IDistrictRepository, InMemoryDistrictRepository>();
builder.Services.AddScoped<IFetchAllDistrictsUseCase, FetchAllDistrictsUseCase>();
builder.Services.AddScoped<IFetchDistrictByIdUseCase, FetchDistrictByIdUseCase>();

var app = builder.Build();
/*---------------------------------*/
// middleware registrations
app.UseExceptionHandler(opt => { });
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

app.Run();

public partial class Program { }
