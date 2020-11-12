using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroDojoGateway.WebBff.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public readonly HttpClient _client;

        public ApiController(HttpClient client)
        {
            _client = client;
        }

        [HttpGet, HttpPost, HttpPut, HttpDelete]
        public async Task<ActionResult> PerformRequest<TResult>(string requestUrl, object requestBody = null)
        {
            try
            {
                HttpResponseMessage response = null;
                string requestMethod = Request.Method.ToString();

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(requestBody, serializeOptions);
                StringContent frame = new StringContent(json, Encoding.UTF8, "Application/json");

                switch (requestMethod)
                {
                    case "GET":
                        response = await _client.GetAsync(requestUrl).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            string jsonString = await response.Content.ReadAsStringAsync();
                            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                            var result = JsonSerializer.Deserialize<TResult>(jsonString, options);
                            return Ok(result);
                        }
                        break;

                    case "POST":
                        response = await _client.PostAsync(requestUrl, frame).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            return Created("", requestBody);
                        }
                        break;

                    case "PUT":
                        response = await _client.PutAsync(requestUrl, frame).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            return Ok();
                        }
                        break;

                    case "DELETE":
                        response = await _client.DeleteAsync(requestUrl).ConfigureAwait(false);
                        if (response.IsSuccessStatusCode)
                        {
                            return Ok();
                        }
                        break;
                }

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode);
                }

                return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
