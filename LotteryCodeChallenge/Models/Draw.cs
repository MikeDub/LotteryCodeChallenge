using System;

namespace LotteryCodeChallenge.Models
{
    /// <summary>
    /// Represents the base details of a lotto draw without context
    /// </summary>
    public abstract class Draw : IDraw
    {
        /// <inheritdoc />
        public string ProductId { get; set; }
        /// <inheritdoc />
        public int DrawNumber { get; set; }
        /// <inheritdoc />
        public string DrawDisplayName { get; set; }
        /// <inheritdoc />
        public DateTimeOffset DrawDate { get; set; }
        /// <inheritdoc />
        public string DrawLogoUrl { get; set; }
        /// <inheritdoc />
        public string DrawType { get; set; }
        /// <inheritdoc />
        public decimal? Div1Amount { get; set; }
        /// <inheritdoc />
        public bool IsDiv1Estimated { get; set; }
        /// <inheritdoc />
        public bool IsDiv1Unknown { get; set; }
        /// <inheritdoc />
        public DateTimeOffset DrawCloseDateTimeUtc { get; set; }
        /// <inheritdoc />
        public DateTimeOffset DrawEndSellDateTimeUtc { get; set; }
    }
}
