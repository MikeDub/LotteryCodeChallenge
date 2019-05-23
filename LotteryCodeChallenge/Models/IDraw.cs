using System;

namespace LotteryCodeChallenge.Models
{
    /// <summary>
    /// A lotto draw
    /// </summary>
    public interface IDraw
    {
        /// <summary>
        /// The Id of the lotto draw
        /// </summary>
        string ProductId { get; set; }
        /// <summary>
        /// The number of the draw
        /// </summary>
        int DrawNumber { get; set; }
        /// <summary>
        /// The friendly display name of the draw
        /// </summary>
        string DrawDisplayName { get; set; }
        /// <summary>
        /// The date on which the draw occurs
        /// </summary>
        DateTimeOffset DrawDate { get; set; }
        /// <summary>
        /// The logo representation of the draw 
        /// </summary>
        string DrawLogoUrl { get; set; }
        /// <summary>
        /// The type of draw
        /// </summary>
        string DrawType { get; set; }
        /// <summary>
        /// The monetary value of the division one prize in the draw - Assuming this maybe nullable if the Div1 is unknown
        /// </summary>
        decimal? Div1Amount { get; set; }
        /// <summary>
        /// Is the amount of the division one prize an estimation?
        /// </summary>
        bool IsDiv1Estimated { get; set; }
        /// <summary>
        /// Is the amount of division one prize unknown?
        /// </summary>
        bool IsDiv1Unknown { get; set; }
        /// <summary>
        /// The date / time the draw closes in UTC
        /// </summary>
        DateTimeOffset DrawCloseDateTimeUtc { get; set; }
        /// <summary>
        /// The date / time the draw stops selling tickets in UTC
        /// </summary>
        DateTimeOffset DrawEndSellDateTimeUtc { get; set; }
    }
}