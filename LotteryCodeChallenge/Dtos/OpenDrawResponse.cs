using LotteryCodeChallenge.Models;

namespace LotteryCodeChallenge.Dtos
{
    /// <summary>
    /// Response object from the open draws API 
    /// </summary>
    public class OpenDrawResponse : DrawResponse
    {
        /// <summary>
        /// The draws currently open
        /// </summary>
        public OpenDraw[] Draws { get; set; }
    }
}
