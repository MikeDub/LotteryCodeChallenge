using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using LotteryCodeChallenge.Dtos;
using LotteryCodeChallenge.Models;
using LotteryCodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryCodeChallenge.Controllers
{
    [Route("api/draws")]
    public class LottoDrawController : Controller
    {
        /// <summary>
        /// Service to retrieve lotto records
        /// </summary>
        private readonly ILottoDrawService _lottoDrawService;

        public LottoDrawController(ILottoDrawService lottoDrawService)
        {
            _lottoDrawService = lottoDrawService;
        }

        /// <summary>
        /// Gets a list of the current lotto draws
        /// </summary>
        [HttpPost("current")]
        public async Task<ObjectResult> Current([FromBody] DrawRequest request)
        {
            IEnumerable<CurrentDraw> response = null;
            try
            {
                // If the basic request has not been supplied properly, exit straight away
                if (!request.IsValid())
                    return BadRequestResult();

                response = await _lottoDrawService.GetCurrentDraws(request);
            }
            catch (InvalidDataException ide)
            {
                return BadRequest($"Invalid Request: {ide.Message}");
            }
            catch (Exception ex) // In the case of an internal server error, return a general 500 (generally would log this).
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, response);
            }

            return new OkObjectResult(response);
        }

        /// <summary>
        /// Gets a list of the open lotto draws
        /// </summary>
        [HttpPost("open")]
        public async Task<ObjectResult> Open([FromBody] DrawRequest request)
        {
            IEnumerable<OpenDraw> response = null;
            try
            {
                // If the basic request has not been supplied properly, exit straight away
                if (!request.IsValid())
                    return BadRequestResult();

                response = await _lottoDrawService.GetOpenDraws(request);
            }
            catch (InvalidDataException ide)
            {
                return BadRequest($"Invalid Request: {ide.Message}");
            }
            catch (Exception ex) // In the case of an internal server error, return a general 500 (generally would log this).
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, response);
            }

            return new OkObjectResult(response);
        }

        /// <summary>
        /// For when the request doesn't seem right.
        /// </summary>
        private BadRequestObjectResult BadRequestResult()
        {
            ModelState.AddModelError("InvalidRequest", "Request does not have a valid CompanyId or MaxDrawCount.");
            return BadRequest(ModelState);
        }

    }
}
