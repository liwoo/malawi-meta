using System.Net;
using FluentAssertions;
using MalawiMeta.Api.TransferObjects;
using MalawiMeta.Test.Fixtures;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MalawiMeta.Test.Integration.DistrictApiTests;

public class FetchAllDistrictApiTest : IClassFixture<TestApplicationFactory<Program>>
{
   private readonly TestApplicationFactory<Program> _factory;

   public FetchAllDistrictApiTest(TestApplicationFactory<Program> factory)
   {
      _factory = factory;
   }
   
   [Fact]
   public async Task Get_All_Districts_Endpoint_With_Correct_Parameters_Should_Return_All_Districts()
   {
      var client = _factory.CreateClient();
      var response = await client.GetAsync("/api/districts");
      response.EnsureSuccessStatusCode();
      var responseString = await response.Content.ReadAsStringAsync();
      var districts = JsonConvert.DeserializeObject<IEnumerable<DistrictResponseDto>>(responseString);
      districts.Should().NotBeEmpty();
   }
   
   [Fact]
   public async Task Get_All_Districts_Endpoint_With_Wron_Endpoint_Should_Return_Exception()
   {
      var client = _factory.CreateClient();
      var response = await client.GetAsync("/apis/districts/");
      response.StatusCode.Should().Be((HttpStatusCode) StatusCodes.Status404NotFound);
   }
}