namespace KCIAO.API.Application.Dtos
{
    public class RecommendationDto
    {
        public string ClienteId { get; set; }
        public List<string> Recommendations { get; set; }
    }
}
