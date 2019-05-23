namespace LotteryCodeChallenge.Models
{
    /// <summary>
    /// An lotto draw that has not yet commenced and open for ticket purchase
    /// </summary>
    public class OpenDraw : Draw
    {
        /// <summary>
        /// The number of seconds until the draw is commenced
        /// </summary>
        public double DrawCountDownTimerSeconds { get; set; }

        // Example Data Below for Open Draws:

        //"ProductId": "LuckyLotteries5",
        //"DrawNumber": 1323,
        //"DrawDisplayName": "Mega Jackpot $1,000,000",
        //"DrawDate": "2019-05-23T00:00:00",
        //"DrawLogoUrl": "http://media.tatts.com/TattsServices/Lotto/Products/LuckyLotteries_v1.png",
        //"DrawType": "Jackpot",
        //"Div1Amount": 1000000,
        //"IsDiv1Estimated": false,
        //"IsDiv1Unknown": false,
        //"DrawCloseDateTimeUTC": "2400-01-01T00:00:00",
        //"DrawEndSellDateTimeUTC": "2400-01-01T00:00:00",

        //"DrawCountDownTimerSeconds": 12010971640
    }
}