using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fs_engineer_test_api.Models;

namespace fs_engineer_test_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class Search : ControllerBase
    {
        private readonly ISearchApi _searchApi;

        public Search(ISearchApi searchApi)
        {
            _searchApi = searchApi;
        }

        [HttpGet]
        public async Task<IActionResult> GetSearchResults(string pQuery)
        {
            var result = await _searchApi.GetSearchResultsAsync(pQuery);

            return result.IsSuccess ? (IActionResult)new OkObjectResult(result) : new BadRequestObjectResult(result);
        }
    }
}
