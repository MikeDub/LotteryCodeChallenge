namespace LotteryCodeChallenge.Models
{
    /// <summary>
    /// The details for a current lotto draw
    /// </summary>
    public class CurrentDraw : Draw
    {
        /// <summary>
        /// The Pending Div 1 Amount, example proves that this is a nullable field
        /// </summary>
        public double? PendingDiv1Amount { get; set; }

        /// <summary>
        /// Is the draw almost sold out?
        /// </summary>
        public bool NearlySoldOut { get; set; }

        // Data source for Current Draw:

        //"ProductId": "LuckyLotteries2",
        //"DrawNumber": 10290,
        //"DrawDisplayName": "Super Jackpot $1,150,000",
        //"DrawDate": "2019-05-24T00:00:00",
        //"DrawLogoUrl": "http://media.tatts.com/TattsServices/Lotto/Products/LuckyLotteries_v1.png",
        //"DrawType": "Jackpot",
        //"Div1Amount": 1150000,
        //"IsDiv1Estimated": false,
        //"IsDiv1Unknown": false,
        //"DrawCloseDateTimeUTC": "2400-01-01T00:00:00",
        //"DrawEndSellDateTimeUTC": "2400-01-01T00:00:00",

        //"PendingDiv1Amount": null,
        //"NearlySoldOut": false
    }
}