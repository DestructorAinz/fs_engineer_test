namespace fs_engineer_test_api.Models.Entities
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public int? Status_code { get; set; }
    }
}
