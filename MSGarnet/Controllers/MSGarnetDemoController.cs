using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MSGarnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MSGarnetDemoController : ControllerBase
    {
        private readonly ILogger<MSGarnetDemoController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public MSGarnetDemoController(ILogger<MSGarnetDemoController> logger, HttpClient httpClient, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get(string key)
        {
            var client = new RestClient("https://localhost:44353/MSGarnetDemo/get");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Access-Control-Allow-Origin", "*");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                key = key,
                value = "value1"
            });

            var response = await client.ExecuteAsync(request);

            return Ok(response.Content);
        }

        [HttpGet]
        [Route("Set")]
        public async Task<IActionResult> Set(string key, string value)
        {
            var client = new RestClient("https://localhost:44353/MSGarnetDemo/set");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Access-Control-Allow-Origin", "*");
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                key = key,
                value = value
            });

            var response = await client.ExecuteAsync(request);

            return Ok(response.Content);
        }


        [HttpGet]
        [Route("GetGarnet")]
        public async Task<IActionResult> GetGarnet()
        {
            //using var server = new GarnetClient("localhost", 4321);
            //await server.ConnectAsync();

            //var setData = await server.StringSetAsync("key1", "value1");

            //var getData = await server.StringGetAsync("key1");

            //var pong = await server.PingAsync();
            //if (pong != "PONG")
            //    throw new Exception("PingAsync: Error");

            return Ok("Ping: Success");

        }

    }
}
