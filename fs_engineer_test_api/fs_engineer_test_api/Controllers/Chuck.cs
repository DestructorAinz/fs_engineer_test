using fs_engineer_test_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fs_engineer_test_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class Chuck : ControllerBase
    {
        private readonly IChuckApi _chuckApi;

        public Chuck(IChuckApi chuckApi)
        {
            _chuckApi = chuckApi;
        }

        [HttpGet("Categories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _chuckApi.GetCategoriesAsync();

            return result.IsSuccess ? (IActionResult)new OkObjectResult(result) : new BadRequestObjectResult(result);
        }
    }
}
