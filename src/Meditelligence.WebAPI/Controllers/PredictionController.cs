using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Seeder;
using Meditelligence.DTOs.Read;
using Meditelligence.WebAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Services;
using SQLitePCL;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Meditelligence.WebAPI.Controllers
{
    [EnableCors("Policy")]
    [ApiController]
    [Route("[controller]")]
    public class PredictionController : Controller
    {
        private readonly MeditelligenceDBContext _context;
        private readonly IDiseasePredictionService _predictionService;

        public PredictionController(MeditelligenceDBContext context, IDiseasePredictionService predictionService)
        {
            _context = context;
            _predictionService = predictionService;
        }

        /// <summary>
        /// An endpoint used to make a prediction on diagnosis given a list of symptoms..
        /// </summary>
        /// <param name="symptoms">The list of symptoms the user has entered.</param>
        /// <returns>An <see cref="ActionResult"/> containing status code and message content.</returns>
        /// <response code="200">Ok: should contain a list of <see cref="IllnessReadDto"/>.</response>
        /// <response code="400">Bad request: An error occurred somewhere and details will be passed back via a string.</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<PredictionReadDto>> PredictiveDiagnosis([FromBody]List<string> symptoms)
        {
            if (symptoms is null || symptoms.Count < 3)
            {
                return BadRequest("You must provide at least 3 symptoms to allow us to make a prediction.");
            }
            try
            {
                var result = _predictionService.Predict(symptoms);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// This may be called, but if the data is already in the DB, it will not populate any more records.
        /// </summary>
        /// <returns>An <see cref="FileRecord"/> containing information about what was processed.</returns>
        [ExcludeFromCodeCoverage(Justification = "This is purely for populating the db, only gets called once when setting up the database.")]
        [HttpGet("SeedDataFromSpreadsheet")]
        public ActionResult<FileRecord> GetFileRecords()
        {
            var result = CsvFilePopulator.ReadFileRecords();
            CsvFilePopulator.PopulateDatabaseRecords(_context, result);

            return Ok(result);
        }
    }
}
