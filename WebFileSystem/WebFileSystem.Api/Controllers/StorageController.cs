using Microsoft.AspNetCore.Mvc;

namespace WebFileSystem.Api.Controllers
{
    [Route("api/storage")]
    [ApiController]
    public class StorageController : ControllerBase
    {

        [HttpGet("get")]
        public string Rettt()
        {
            return "salom";
        }
    }
}
