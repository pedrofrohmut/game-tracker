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
      var url = this.config["TRACKER_API_URL"] + "/profile/" + platform + "/" + gamertag;
      try
      {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("TRN-Api-Key", config["TRN-Api-Key"]);
        Console.WriteLine("API_KEY", config["TRN-Api-Key"]);
        var responseMessage = await client.GetAsync(url.ToString());
        if (responseMessage.IsSuccessStatusCode)
          return Ok(await responseMessage.Content.ReadAsAsync<object>());
        else
          return Ok(await responseMessage.Content.ReadAsAsync<object>());
        // return NotFound(new { message = "Profile not found" });
      }
      catch (HttpRequestException ex)
      {
        return Ok(new { message = "Server Error trying to get profile from API: " + ex.Message });
      }
    }
  }
}