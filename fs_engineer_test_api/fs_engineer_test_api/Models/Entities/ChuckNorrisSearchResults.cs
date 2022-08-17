namespace fs_engineer_test_api.Models.Entities
{
    public class ChuckNorrisSearchResults
    {
        public int Total { get; set; }
        public List<ChuckNorrisJokes> Result { get; set; }
    }
}
