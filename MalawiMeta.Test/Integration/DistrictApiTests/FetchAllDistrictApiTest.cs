using System.Net;
using FluentAssertions;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Test.Integration.Fixtures;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MalawiMeta.Test.Integration.DistrictApiTests;

[Collection("TestApplicationFactory collection")]
public class FetchAllDistrictApiTest
{
   private readonly TestApplicationFactory<Program> _factory;

   public FetchAllDistrictApiTest(TestApplicationFactory<Program> factory)
   {
      _factory = factory;
   }
   
   [Fact]
   public async Task GetAllDistrictsEndpoint_WithCorrectParameters_ShouldReturnAllDistricts()
   {
      var client = _factory.CreateClient();
      var response = await client.GetAsync("/api/districts");
      response.EnsureSuccessStatusCode();
      var responseString = await response.Content.ReadAsStringAsync();
      var districts = JsonConvert.DeserializeObject<IEnumerable<DistrictResponseDto>>(responseString);
      districts.Should().NotBeEmpty();
   }
   
   [Fact]
   public async Task GetAllDistrictsEndpoint_WithWrongEndpoint_ShouldReturnException()
   {
      var client = _factory.CreateClient();
      var response = await client.GetAsync("/apis/districts/");
      response.StatusCode.Should().Be((HttpStatusCode) StatusCodes.Status404NotFound);
   }
   
}