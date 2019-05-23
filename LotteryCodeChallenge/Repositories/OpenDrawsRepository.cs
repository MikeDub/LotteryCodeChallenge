using System.Collections.Generic;
using System.Net.Http;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Models;

namespace LotteryCodeChallenge.Repositories
{
    /// <summary>
    /// Gets the open draws from the API Data Source
    /// </summary>
    public class OpenDrawsRepository : HttpRepository<DrawRequest, OpenDrawResponse>
    {
        public OpenDrawsRepository() 
            : base("https://data.api.thelott.com/sales/vmax/web/data/lotto/opendraws")
        {
            
        }
    }
}