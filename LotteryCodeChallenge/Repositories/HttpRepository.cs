using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LotteryCodeChallenge.Repositories
{
    /// <inheritdoc />
    public abstract class HttpRepository<TRequest, TResponse> : IHttpRepository<TRequest, TResponse>
    {
        /// <summary>
        /// Defines if an error is thrown on non successful http response code.
        /// </summary>
        private readonly bool _throwOnNonSuccessResponse;

        /// <summary>
        /// The http client used for requests.
        /// </summary>
        private readonly HttpClient _httpClient;

        /// <summary>
        /// For performing entity operations on a single route / path
        /// </summary>
        protected string RepositoryApiPath;

        /// <summary>
        /// Constructs a new Http Client base class
        /// </summary>
        protected HttpRepository(string repositoryPath = null, bool throwOnNonSuccessResponse = true)
        {
            RepositoryApiPath = repositoryPath;
            _throwOnNonSuccessResponse = throwOnNonSuccessResponse;
            _httpClient = HttpClientFactory.Create();
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <inheritdoc />
        public virtual async Task<TResponse> GetAsync(string path = null)
        {
            // Make the request
            var response = await _httpClient.GetAsync(ResolvePath(path));

            // Handle the response
            if (_throwOnNonSuccessResponse) response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(content);
            return result;
        }

        /// <inheritdoc />
        public virtual async Task<TResponse> PostAsync(TRequest requestBody)
        {
            // Serialize and make the request.
            var objectAsJson = JsonConvert.SerializeObject(requestBody, Formatting.Indented, new JsonSerializerSettings() {DefaultValueHandling = DefaultValueHandling.Populate});
            HttpContent content = new StringContent(objectAsJson);
            var response = await _httpClient.PostAsync(RepositoryApiPath, content);

            // Handle the response
            if (_throwOnNonSuccessResponse) response.EnsureSuccessStatusCode();
            var responseEntity = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TResponse>(responseEntity);
            return result;

        }

        /// <summary>
        /// Resolves the Api path, if a custom path is defined, will use this, else will use the pre-defined RepositoryApiPath
        /// </summary>
        private string ResolvePath(string customPath = null)
        {
            return customPath ?? RepositoryApiPath;
        }
    }
}