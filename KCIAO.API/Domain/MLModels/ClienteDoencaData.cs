namespace KCIAO.API.Domain.MLModels
{
    public class ClienteDoencaData
    {
        public string ClienteId { get; set; }
        public string DoencaId { get; set; }
        public bool HasDisease { get; set; }
    }

    public class DentalCareRecommendation
    {
        public string ClienteId { get; set; }
        public string Recommendation { get; set; }
    }
}
