using System.Threading.Tasks;

namespace LotteryCodeChallenge.Repositories
{
    /// <summary>
    /// Represents an asynchronous http repository implementation
    /// </summary>
    public interface IHttpRepository<in TRequest, TResponse>
    {
        /// <summary>
        /// Gets an entity from the requested path (if null uses the default path)
        /// </summary>
        Task<TResponse> GetAsync(string path);

        /// <summary>
        /// Gets an entity from the default path with the defined request parameters.
        /// </summary>
        Task<TResponse> PostAsync(TRequest requestBody);
    }
}
