namespace fs_engineer_test_api.Models.Entities
{
    public class SearchResults
    {
        public PeopleResponse People_search_data { get; set; }
        public ChuckNorrisSearchResults Jokes { get; set; }
    }
}
