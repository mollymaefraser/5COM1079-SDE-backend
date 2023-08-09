using Meditelligence.DTOs.Read;

namespace Meditelligence.WebAPI.Services
{
    public interface IDiseasePredictionService
    {
        List<IllnessReadDto> Predict(List<string> symptoms);
    }
}