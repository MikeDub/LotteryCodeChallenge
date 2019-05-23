namespace LotteryCodeChallenge.Dtos
{
    /// <summary>
    /// Api Request for requesting information about lotto draws
    /// </summary>
    public class DrawRequest
    {
        public string CompanyId { get; set; }
        public int MaxDrawCount { get; set; }
        public string[] OptionalProductFilter { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(CompanyId) && MaxDrawCount > 0;
        }
    }
}
