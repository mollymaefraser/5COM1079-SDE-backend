using Meditelligence.DataAccess.Context;
using Meditelligence.DataAccess.Seeder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Services;
using SQLitePCL;
using System.Data.Common;

namespace Meditelligence.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredictionController : Controller
    {
        private readonly MeditelligenceDBContext _context;

        public PredictionController(MeditelligenceDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<string> PredictiveDiagnosis([FromForm]List<string> Symptoms)
        {
            // create join table for names
            var dataset = (from ep in _context.IllnessToSymptoms
                           join illness in _context.Illnesses on ep.IllnessRefID equals illness.IllnessID
                           join symptom in _context.Symptoms on ep.SymptomRefID equals symptom.SymptomID
                           select new
                           {
                               IllnessName = illness.Name,
                               SymptomName = symptom.Name,
                           });

            // convert to dictionary
            Dictionary<string, List<string>> symptomDiseaseAssociations = new();
            var potentialDiseases = new Dictionary<string, int>();
            foreach (var record in dataset)
            {
                if (symptomDiseaseAssociations.ContainsKey(record.IllnessName))
                {
                    symptomDiseaseAssociations[record.IllnessName].Add(record.SymptomName);
                }
                else
                {
                    symptomDiseaseAssociations.Add(record.IllnessName, new List<string>() { record.SymptomName });
                    potentialDiseases.Add(record.IllnessName, 0);
                }
            }

            // match symptoms
            foreach (var symptom in Symptoms)
            {
                foreach(var record in symptomDiseaseAssociations)
                {
                    if (record.Value.Contains(symptom))
                    {
                        potentialDiseases[record.Key] += 1;
                    }
                }
                
            }

            Console.WriteLine("Symptoms matched per disease:");
            foreach (var disease in potentialDiseases)
            {
                Console.WriteLine($"{disease.Key}: {disease.Value}");
            }

            return Ok("we made it!");
        }

        [HttpGet("SeedDataFromSpreadsheet")]
        public ActionResult<FileRecord> GetFileRecords()
        {
            var result = CsvFilePopulator.ReadFileRecords();
            CsvFilePopulator.PopulateDatabaseRecords(_context, result);

            return Ok(result);
        }
    }
}
