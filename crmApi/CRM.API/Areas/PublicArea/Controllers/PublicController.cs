using System.ComponentModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Areas.PublicArea.Controllers
{
    [Area("PublicArea")]
    [DisplayName("Public Controler")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class PublicController : ControllerBase
    {
    }
}
