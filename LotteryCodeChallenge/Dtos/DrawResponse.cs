namespace LotteryCodeChallenge.Dtos
{
    /// <summary>
    /// Response from theLotts Api with Lotto Draws 
    /// </summary>
    public class DrawResponse
    {
        /// <summary>
        /// Any errors returned from the Api
        /// </summary>
        public ServiceErrorInfo ErrorInfo { get; set; }

        /// <summary>
        /// Was it a successful request?
        /// </summary>
        public bool Success { get; set; }
    }
}
