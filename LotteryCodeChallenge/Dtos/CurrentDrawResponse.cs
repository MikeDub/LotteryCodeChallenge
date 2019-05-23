using LotteryCodeChallenge.Models;

namespace LotteryCodeChallenge.Dtos
{
    /// <summary>
    /// The response from the current draws api
    /// </summary>
    public class CurrentDrawResponse : DrawResponse
    {
        /// <summary>
        /// The currently active draws
        /// </summary>
        public CurrentDraw[] CurrentDraws { get; set; }
    }
}
