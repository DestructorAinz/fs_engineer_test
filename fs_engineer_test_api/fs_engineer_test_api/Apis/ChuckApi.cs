using fs_engineer_test_api.Models;
using fs_engineer_test_api.Models.Entities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace fs_engineer_test_api.Apis
{
    public class ChuckApi : IChuckApi
    {
        private readonly IConfiguration _configuration;

        public ChuckApi(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ApiResponse<string[]>> GetCategoriesAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var endPoints = _configuration.GetSection("Endpoints");
                    string url = endPoints["ChuckCategories"];

                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<string[]>(jsonResponse);

                    return new ApiResponse<string[]>
                    {
                        Data = result,
                        IsSuccess = true
                    };
                }
            }
            catch(Exception ex)
            {
                return new ApiResponse<string[]>
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }

        public async Task<ApiResponse<ChuckNorrisSearchResults>> GetJokesAsync(string pQuery)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var endPoints = _configuration.GetSection("Endpoints");
                    string url = endPoints["ChuckJokes"] + pQuery;

                    var response = await client.GetAsync(url);

                    response.EnsureSuccessStatusCode();

                    var jsonResponse = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<ChuckNorrisSearchResults>(jsonResponse);

                    return new ApiResponse<ChuckNorrisSearchResults>
                    {
                        Data = result,
                        IsSuccess = true
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<ChuckNorrisSearchResults>
                {
                    Message = ex.Message,
                    IsSuccess = false
                };
            }
        }
    }
}
