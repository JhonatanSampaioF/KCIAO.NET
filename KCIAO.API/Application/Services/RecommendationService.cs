using KCIAO.API.Domain.Entities;
using KCIAO.API.Domain.MLModels;
using Microsoft.ML;
using Microsoft.ML.Data;

namespace KCIAO.API.Application.Services
{
    public class RecommendationService
    {
        private readonly MLContext _mlContext;
        private ITransformer _model;

        public RecommendationService()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<ClienteDoencaData> trainingData)
        {
            var data = _mlContext.Data.LoadFromEnumerable(trainingData);

            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "DoencaIdEncoded", inputColumnName: nameof(ClienteDoencaData.DoencaId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "ClienteIdEncoded", inputColumnName: nameof(ClienteDoencaData.ClienteId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: nameof(ClienteDoencaData.HasDisease),
                    matrixColumnIndexColumnName: "DoencaIdEncoded",
                    matrixRowIndexColumnName: "ClienteIdEncoded"));

            _model = pipeline.Fit(data);
        }

        public IEnumerable<string> PredictRecommendations(string clienteId)
        {
            // Exemplo: retorna recomendações baseadas no cliente
            // Implementar lógica para prever os cuidados

            // Como exemplo simples, retorne recomendações fixas:
            if (clienteId == null)
                return new List<string> { "Recomendação geral: escove os dentes 3x ao dia, use fio dental." };

            // Aqui você integraria a predição ML para retornar recomendações baseadas nas doenças
            return new List<string> { "Cuidados para gengivite", "Evitar doces excessivos" };
        }
    }
}
