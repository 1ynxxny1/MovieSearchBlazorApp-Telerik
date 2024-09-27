using MovieSearchBlazorApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MovieSearchBlazorApp.Services
{
    public class MovieService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "2a62c73";

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<MovieSearchResult[]> SearchMoviesAsync(string query)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse>($"http://www.omdbapi.com/?s={query}&apikey={ApiKey}");
            return response?.Search;
        }

        public async Task<MovieDetail> GetMovieDetailAsync(string imdbID)
        {
            return await _httpClient.GetFromJsonAsync<MovieDetail>($"http://www.omdbapi.com/?i={imdbID}&apikey={ApiKey}");
        }

        private class ApiResponse
        {
            public MovieSearchResult[] Search { get; set; }
        }
    }
}
