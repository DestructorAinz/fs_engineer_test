using fs_engineer_test_api.Models;
using fs_engineer_test_api.Models.Entities;
using Newtonsoft.Json;

namespace fs_engineer_test_api.Apis
{
    public class SwapiApi : ISwapiApi
    {
        private readonly IConfiguration _configuration;

        public SwapiApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiResponse<PeopleResponse>> GetPeopleAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var endPoints = _configuration.GetSection("Endpoints");
                    string url = endPoints["SwapiPeople"];

                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<PeopleResponse>(jsonResponse);

                    return new ApiResponse<PeopleResponse>
                    {
                        Data = result,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<PeopleResponse>
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<ApiResponse<PeopleResponse>> SearchPeopleAsync(string pQuery)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var endPoints = _configuration.GetSection("Endpoints");
                    string url = endPoints["SwapiSearch"] + pQuery;

                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<PeopleResponse>(jsonResponse);

                    return new ApiResponse<PeopleResponse>
                    {
                        Data = result,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<PeopleResponse>
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}
