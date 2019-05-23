namespace LotteryCodeChallenge.Models
{
    /// <summary>
    /// Represents an individual Lotto Product
    /// </summary>
    public class LottoProduct
    {
        /// <summary>
        /// The product Id of the product ie. "Super66".
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Whats a product Id without a description? just for kicks...
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Easy conversion of product Id to string
        /// </summary>
        public override string ToString()
        {
            return $"{ProductId}";
        }
    }
}
