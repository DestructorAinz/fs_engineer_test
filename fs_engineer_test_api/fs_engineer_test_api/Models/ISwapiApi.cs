using fs_engineer_test_api.Models.Entities;

namespace fs_engineer_test_api.Models
{
    public interface ISwapiApi
    {
        Task<ApiResponse<PeopleResponse>> GetPeopleAsync();
        Task<ApiResponse<PeopleResponse>> SearchPeopleAsync(string pQuery);
    }
}