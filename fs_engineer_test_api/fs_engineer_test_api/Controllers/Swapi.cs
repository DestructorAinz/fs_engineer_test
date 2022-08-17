using fs_engineer_test_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fs_engineer_test_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Swapi : ControllerBase
    {
        private readonly ISwapiApi _swapiApi;

        public Swapi(ISwapiApi swapiApi)
        {
            _swapiApi = swapiApi;
        }

        [HttpGet("People")]
        public async Task<IActionResult> GetPeople()
        {
            var result = await _swapiApi.GetPeopleAsync();

            return result.IsSuccess ? (IActionResult)new OkObjectResult(result) : new BadRequestObjectResult(result);
        }
    }
}
