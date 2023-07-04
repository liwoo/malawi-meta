using MalawiMeta.Api.Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace MalawiMeta.Test.Fixtures;

public abstract class TestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IDistrictService));
            if (descriptor != null)
            {
                services.Remove(descriptor);
            }

            services.AddScoped<IDistrictService, InMemoryDistrictService>();
        });
    }
}
