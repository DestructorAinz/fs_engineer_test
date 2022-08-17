using fs_engineer_test_api.Models.Entities;

namespace fs_engineer_test_api.Models
{
    public interface ISearchApi
    {
        Task<ApiResponse<SearchResults>> GetSearchResultsAsync(string pQuery);
    }
}