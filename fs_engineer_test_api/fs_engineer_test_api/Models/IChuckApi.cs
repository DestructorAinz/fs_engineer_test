using fs_engineer_test_api.Models.Entities;

namespace fs_engineer_test_api.Models
{
    public interface IChuckApi
    {
        Task<ApiResponse<string[]>> GetCategoriesAsync();
        Task<ApiResponse<ChuckNorrisSearchResults>> GetJokesAsync(string pQuery);
    }
}