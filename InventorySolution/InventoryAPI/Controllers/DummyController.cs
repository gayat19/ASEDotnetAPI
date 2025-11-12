using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        static string name = "InventoryAPI";
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Hello  "+name);
        }

        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            name = value;
            return NoContent();
        }
    }
}
