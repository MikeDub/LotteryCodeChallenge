using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Threading.Tasks;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Models;
using LotteryCodeChallenge.Repositories;

namespace LotteryCodeChallenge.Services
{
    /// <inheritdoc />
    public class LottoDrawService : ILottoDrawService
    {
        /// <summary>
        /// Lotto Draw Repositories
        /// </summary>
        private readonly CurrentDrawRepository _currentDrawRepository;
        private readonly OpenDrawsRepository _openDrawsRepository;

        public LottoDrawService(OpenDrawsRepository openDrawsRepository, CurrentDrawRepository currentDrawRepository)
        {
            _openDrawsRepository = openDrawsRepository ?? throw new ArgumentNullException(
                                       nameof(openDrawsRepository), "open draws repository cannot be null.");
            _currentDrawRepository = currentDrawRepository ?? throw new ArgumentNullException(
                                         nameof(currentDrawRepository), "current draw repository cannot be null.");
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CurrentDraw>> GetCurrentDraws(DrawRequest request)
        {
            var draws = await _currentDrawRepository.PostAsync(request);
            ValidateResponse(draws);
            return draws.CurrentDraws;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<OpenDraw>> GetOpenDraws(DrawRequest request)
        {
            var draws = await _openDrawsRepository.PostAsync(request);
            ValidateResponse(draws);
            return draws.Draws;
        }

        /// <summary>
        /// Ensure the draws returned from the repository is valid.
        /// </summary>
        private void ValidateResponse(DrawResponse drawResponse)
        {
            if (drawResponse == null)
                throw new InvalidDataException("No results were returned from the data source.");
            if (!drawResponse.Success)
                throw new InvalidDataException("The result from the data source was not successful.", new Exception(drawResponse.ErrorInfo.DisplayMessage));

            if (drawResponse is CurrentDrawResponse currentResponse)
            {
                ValidArrayNotNullOrEmpty(currentResponse.CurrentDraws);   
            }

            if (drawResponse is OpenDrawResponse openResponse)
            {
                ValidArrayNotNullOrEmpty(openResponse.Draws);
            }
        }

        /// <summary>
        /// Ensure we have some valid data in the array
        /// </summary>
        private void ValidArrayNotNullOrEmpty(IEnumerable<Draw> draws)
        {
            if (draws == null)
                throw new InvalidDataException("No draws were returned from the data source.");
            if (draws.ToList().Count == 0)
                throw new DataException("The response was valid, but no draws were returned from the data source.");
        }
    }
}
