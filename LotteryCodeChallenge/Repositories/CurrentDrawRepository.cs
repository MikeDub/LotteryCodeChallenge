using System.Collections.Generic;
using System.Net.Http;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Models;

namespace LotteryCodeChallenge.Repositories
{
    /// <summary>
    /// Gets the current draw from the API data source
    /// </summary>
    public class CurrentDrawRepository : HttpRepository<DrawRequest, CurrentDrawResponse>
    {
        public CurrentDrawRepository() 
            : base("https://data.api.thelott.com/sales/vmax/web/data/lotto/luckylotteries/currentdraw")
        {

        }

    }
}