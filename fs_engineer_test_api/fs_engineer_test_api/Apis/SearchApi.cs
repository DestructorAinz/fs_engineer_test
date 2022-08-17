using fs_engineer_test_api.Models;
using fs_engineer_test_api.Models.Entities;

namespace fs_engineer_test_api.Apis
{
    public class SearchApi : ISearchApi
    {
        private readonly IChuckApi _chuckApi;
        private readonly ISwapiApi _swapiApi;

        public SearchApi(IChuckApi chuckApi, ISwapiApi swapiApi)
        {
            _chuckApi = chuckApi;
            _swapiApi = swapiApi;
        }

        public async Task<ApiResponse<SearchResults>> GetSearchResultsAsync(string pQuery)
        {
            try
            {
                var chuckResults = await _chuckApi.GetJokesAsync(pQuery);
                var swapiResults = await _swapiApi.SearchPeopleAsync(pQuery);

                var results = new SearchResults
                {
                    People_search_data = swapiResults.Data,
                    Jokes = chuckResults.Data
                };

                return new ApiResponse<SearchResults>
                {
                    Data = results,
                    IsSuccess = true
                };
            }
            catch(Exception ex)
            {
                return new ApiResponse<SearchResults>
                {
                    Message = ex.Message,
                    IsSuccess = true
                };
            }
        }
    }
}
