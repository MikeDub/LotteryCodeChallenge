using System.Collections.Generic;
using System.Threading.Tasks;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Models;

namespace LotteryCodeChallenge.Services
{
    /// <summary>
    /// Service to retrieve all available types of lotto draws
    /// </summary>
    public interface ILottoDrawService
    {
        /// <summary>
        /// Gets a collection of current draws
        /// </summary>
        Task<IEnumerable<CurrentDraw>> GetCurrentDraws(DrawRequest request);

        /// <summary>
        /// Gets a collection of open draws
        /// </summary>
        Task<IEnumerable<OpenDraw>> GetOpenDraws(DrawRequest request);
    }
}