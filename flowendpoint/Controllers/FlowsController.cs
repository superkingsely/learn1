

using System.Text.Json;
using flowendpoint.DTOs;
using flowendpoint.HelperFunc;
using Microsoft.AspNetCore.Mvc;

namespace flowendpoint.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlowsController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration _configuration = configuration;

    [HttpPost("endpoint")]
    public IActionResult Endpoint(FlowEncryptedRequest req)
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

        try
        {
            var decryptedJson = DecryptFlowRequest.DecryptFlow(
                        req,
                        rsa,
                        out var aesKey,
                        out var iv
                    );

                     using var doc = JsonDocument.Parse(decryptedJson);
                    var root = doc.RootElement;

                    var action = root.GetProperty("action").GetString();

                    object response;
                     if (action == "ping")
                    {
                        response = new
                        {
                            version = "3.0",
                            screen = "screen_asnlyt",
                            data = new { status = "active" }
                        };
                    }
            else
            {
                response = new { message = "Unknown action" };
            }
                    return Ok(response);

        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message,"cool");
            // FIX: You MUST return something here
            return StatusCode(500, "Internal decryption error");
        }
    }
}