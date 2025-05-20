using KCIAO.API.Application.Dtos;
using KCIAO.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KCIAO.API.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationService _recommendationService;

        public RecommendationController(RecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet("{clienteId}")]
        public ActionResult<RecommendationDto> GetRecommendations(string clienteId)
        {
            var recs = _recommendationService.PredictRecommendations(clienteId);

            var dto = new RecommendationDto
            {
                ClienteId = clienteId,
                Recommendations = recs.ToList()
            };

            return Ok(dto);
        }
    }
}
