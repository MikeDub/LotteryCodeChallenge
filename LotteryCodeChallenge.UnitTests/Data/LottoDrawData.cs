using System;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Models;

namespace LotteryCodeChallenge.UnitTests.Data
{
    /// <summary>
    /// Data provider for lotto draw service tests
    /// </summary>
    public static class LottoDrawData
    {
        #region Requests

        public static DrawRequest ValidDrawRequest => new DrawRequest { CompanyId = "Tattersalls", MaxDrawCount = 10 };

        public static string[] ValidProductFilters => new string[] { "TattsLotto", "MonWedLotto", "OzLotto", "Powerball" };

        #endregion

        #region Responses

        #region Valid Responses

        public static CurrentDrawResponse ValidCurrentDrawsResponse => new CurrentDrawResponse
        {
            CurrentDraws = new CurrentDraw[] {ValidCurrentDraw},
            ErrorInfo = null,
            Success = true // Not testing success here, so make sure we don't throw because of not successful.
        };

        public static OpenDrawResponse ValidOpenDrawsResponse => new OpenDrawResponse
        {
            Draws = new OpenDraw[] { ValidOpenDraw },
            ErrorInfo = null,
            Success = true // Not testing success here, so make sure we don't throw because of not successful.
        };


        public static TDrawResponse AbstractSuccessfulAndNoErrorDrawResponse<TDrawResponse>() where TDrawResponse : DrawResponse
        {
            var response = new DrawResponse()
            {
                ErrorInfo = null,
                Success = true
            };
            return (TDrawResponse)Convert.ChangeType(response, typeof(TDrawResponse));
        }

        #endregion


        #region Invalid Responses

        public static CurrentDrawResponse NullCurrentDrawsResponse
        {
            get
            {
                var response = AbstractSuccessfulAndNoErrorDrawResponse<CurrentDrawResponse>(); 
                return response; // Leave Current Draws null
            }
        }

        public static CurrentDrawResponse NotSuccessfulCurrentDrawsResponse => new CurrentDrawResponse()
        {
            CurrentDraws = new CurrentDraw[] { new CurrentDraw() { ProductId = "Powerball" } }, //Don't throw because of this, provide min required data.
            ErrorInfo = null,
            Success = false // Testing this
        };

        public static OpenDrawResponse NullOpenDrawsResponse 
        {
            get
            {
                var response = AbstractSuccessfulAndNoErrorDrawResponse<OpenDrawResponse>();
                return response; // Leave draws null
            }
        }

        public static OpenDrawResponse NotSuccessfulOpenDrawsResponse
        {
            get
            {
                var response = AbstractNotSuccessAndNoErrorDrawResponse<OpenDrawResponse>();
                response.Draws = new [] { new OpenDraw() {ProductId = "Powerball"} };
                return response;
            }
        }
            
        public static TDrawResponse AbstractNotSuccessAndNoErrorDrawResponse<TDrawResponse>() where TDrawResponse : DrawResponse
        {
            var response = new DrawResponse()
            {
                ErrorInfo = null,
                Success = false // Testing this
            };
            return (TDrawResponse)Convert.ChangeType(response, typeof(TDrawResponse));
        }

        #endregion

        #endregion

        #region Draws

        #region Valid

        public static OpenDraw ValidOpenDraw => new OpenDraw() { Div1Amount = 100000, ProductId = "Mega Lotto" };
        public static CurrentDraw ValidCurrentDraw => new CurrentDraw() { Div1Amount = 100000, ProductId = "Powerball 10000" };

        #endregion


        #region Invalid

        public static OpenDraw InvalidOpenDraw => new OpenDraw() { Div1Amount = 0, ProductId = string.Empty };
        public static CurrentDraw InvalidCurrentDraw => new CurrentDraw() { Div1Amount = 0, ProductId = string.Empty };

        #endregion

        #endregion

    }
}
