using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Versioning.Controllers
{
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:ApiVersion}/[Controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        [HttpGet("")]
        [MapToApiVersion("1.0")]
        public string Getv1()
        {
            return "Vendor V1";
        }

        [HttpGet("")]
        [MapToApiVersion("2.0")]
        public string Getv2()
        {
            return "Vendor V2";
        }

        [HttpGet("GetVendor")]
        [MapToApiVersion("1.0")]
        public IActionResult GetVendor1()
        {
            return Ok("Vendor1 Get to be implemented");
        }
        [HttpGet("GetVendor")]
        [MapToApiVersion("2.0")]
        public IActionResult GetVendor2()
        {
            return Ok("Vendor2 Get to be implemented");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("V1 Post to be implemented");
        }
    }
}
