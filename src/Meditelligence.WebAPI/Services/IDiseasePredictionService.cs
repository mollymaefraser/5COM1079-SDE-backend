using Meditelligence.DTOs.Read;

namespace Meditelligence.WebAPI.Services
{
    public interface IDiseasePredictionService
    {
        List<PredictionReadDto> Predict(List<string> symptoms);
    }
}