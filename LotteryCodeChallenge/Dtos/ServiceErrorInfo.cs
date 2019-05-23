namespace LotteryCodeChallenge.Dtos
{
    /// <summary>
    /// Error state object returned by thelott api
    /// </summary>
    public class ServiceErrorInfo
    {
        public int SystemId { get; set; }
        public int ErrorNo { get; set; }
        public string DisplayMessage { get; set; }
        public bool ContactSupport { get; set; }
        public string SupportErrorReference { get; set; }
    }
}
