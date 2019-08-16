using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GameTracker.WebApi.Controllers
{
  [Route("api/v1/apex/profiles")]
  [ApiController]
  public class ProfilesController : ControllerBase
  {
    private readonly IConfiguration config;
    private readonly IHttpClientFactory clientFactory;

    public ProfilesController(
      IConfiguration config,
      IHttpClientFactory clientFactory)
    {
      this.config = config;
      this.clientFactory = clientFactory;
    }

    [HttpGet("{platform}/{gamertag}")]
    public async Task<ActionResult> Get(string platform, string gamertag)
    {
      var url = this.config["TRACKER_API_URL"] + "/profile/" + platform + "/" + gamertag;

      var request = new HttpRequestMessage(HttpMethod.Get, url);
      request.Headers.Add("Accept", "application/json");
      request.Headers.Add("TRN-Api-Key", config["TRN-Api-Key"]);
      var client = this.clientFactory.CreateClient();
      var response = await client.SendAsync(request);
      if (response.IsSuccessStatusCode)
        return Ok(await response.Content.ReadAsAsync<object>());
      else
        return Ok(await response.Content.ReadAsAsync<object>());
    }
  }
}