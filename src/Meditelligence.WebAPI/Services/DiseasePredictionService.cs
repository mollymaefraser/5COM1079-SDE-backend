using AutoMapper;
using Meditelligence.DataAccess.Context;
using Meditelligence.DTOs.Read;
using Meditelligence.Models;
using Microsoft.EntityFrameworkCore;

namespace Meditelligence.WebAPI.Services
{
    /// <summary>
    /// A service class to take in symptoms and generate potential diagnosis(es).
    /// </summary>
    public class DiseasePredictionService : IDiseasePredictionService
    {
        private readonly ILogger<DiseasePredictionService> _logger;
        private readonly MeditelligenceDBContext _context;
        private readonly IMapper _mapper;

        public DiseasePredictionService(ILogger<DiseasePredictionService> logger, MeditelligenceDBContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public List<PredictionReadDto> Predict(List<string> symptoms)
        {
            // create join table for names
            var dataset = (from ep in _context.IllnessToSymptoms
                           join illness in _context.Illnesses on ep.IllnessRefID equals illness.IllnessID
                           join symptom in _context.Symptoms on ep.SymptomRefID equals symptom.SymptomID
                           select new
                           {
                               Illness = illness,
                               Symptom = symptom,
                           });
            // convert to dictionary
            Dictionary<string, List<string>> symptomDiseaseAssociations = new();
            var potentialDiseases = new Dictionary<string, int>();
            foreach (var record in dataset)
            {
                // if illness already in dictionary, add symptom as value to that key 
                if (symptomDiseaseAssociations.ContainsKey(record.Illness.Name))
                {
                    symptomDiseaseAssociations[record.Illness.Name].Add(record.Symptom.Name);
                }
                // otherwise add new key value pair
                else
                {
                    symptomDiseaseAssociations.Add(record.Illness.Name, new List<string>() { record.Symptom.Name });
                    potentialDiseases.Add(record.Illness.Name, 0);
                }
            }

            // match symptoms
            foreach (var symptom in symptoms)
            {
                foreach (var record in symptomDiseaseAssociations)
                {
                    if (record.Value.Contains(symptom))
                    {
                        potentialDiseases[record.Key] += 1;
                    }
                }

            }

            var sortedDiseaseMatches = potentialDiseases.OrderByDescending(x => x.Value).Where(x => x.Value > 0);
            if (sortedDiseaseMatches.Any())
            {
                // Take the top 2 most matched.
                var top2results = sortedDiseaseMatches.Take(2);

                var finalResults = new List<PredictionReadDto>();
                foreach (var disease in top2results)
                {
                    _logger.LogInformation("{illness} : {number of symptoms matched}", disease.Key, disease.Value);
                    var illnessSymptomMatches = dataset.Where(i => i.Illness.Name == disease.Key);

                    var predictionDto = new PredictionReadDto();
                    predictionDto.Illness = _mapper.Map<IllnessReadDto>(illnessSymptomMatches.First().Illness);
                    predictionDto.Symptoms = new();
                    foreach (var match in illnessSymptomMatches)
                    {
                        var symptomDto = _mapper.Map<SymptomReadDto>(match.Symptom);
                        predictionDto.Symptoms.Add(symptomDto);
                    }
                    finalResults.Add(predictionDto);
                }

                return finalResults;
            }
            else
            {
                throw new Exception("There were no diseases matched with the symptoms provided.");
            }
        }
    }
}
