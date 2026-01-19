

using Microsoft.AspNetCore.Mvc;

namespace flowendpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlowsController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("endpoint")]
    public IActionResult Endpoint()
    {   
        // var base64key=Environment.GetEnvironmentVariable("WHATSAPP_PRIVATE_KEY_B64");
        var base64key=_configuration["WHATSAPP_PRIVATE_KEY_B64"];
        if (string.IsNullOrEmpty(base64key))
        {
            return BadRequest("Environment variable WHATSAPP_PRIVATE_KEY_B64 is not set.");
        }
        // conver base64 to string pem
        var pemKey = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(base64key));
        if (string.IsNullOrEmpty(pemKey))
        {
            return BadRequest("Failed to decode PEM key from base64.");
        }
        var rsa = System.Security.Cryptography.RSA.Create();
        // to load our private key in PEM format
        rsa.ImportFromPem(pemKey.ToCharArray());
        Console.WriteLine("okay endpoint hit");
        return Ok("Endpoint called");
    }
}