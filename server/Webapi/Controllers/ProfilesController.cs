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
    private readonly HttpClient client;
    private readonly IConfiguration config;

    public ProfilesController(HttpClient client, IConfiguration config)
    {
      this.client = client;
      this.config = config;
    }

    [HttpGet("{platform}/{gamertag}")]
    public async Task<ActionResult> Get(string platform, string gamertag)
    {
      var url = new StringBuilder(this.config["TRACKER_API_URL"]);
      url.Append($"/profile/{platform}/{gamertag}");
      try
      {
        client.DefaultRequestHeaders.Add("TRN-Api-Key", "2e445edf-1d8e-4950-a330-fe429971b140");
        var responseMessage = await client.GetAsync(url.ToString());
        if (responseMessage.IsSuccessStatusCode)
          return Ok(await responseMessage.Content.ReadAsAsync<object>());
        else
          return NotFound(new { message = "Profile not found" });
      }
      catch (HttpRequestException ex)
      {
        return Ok(new { message = "Server Error trying to get profile from API: " + ex.Message });
      }
    }
  }
}