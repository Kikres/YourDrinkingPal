using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Services.CommonServices
{
    public class CommonServiceComputerVision
    {
        private readonly string _connectionString;
        private readonly string _key;

        public CommonServiceComputerVision(IConfiguration configuration)
        {
            _connectionString = configuration["ComputerVision:ConnectionString"];
            _key = configuration["ComputerVision:Key"];
        }

        public async Task<ImageAnalysis> InspectImage(string imageUrl)
        {
            // Create a computer vision client
            ApiKeyServiceClientCredentials visionCredentials = new(_key);
            ComputerVisionClient vision = new ComputerVisionClient(visionCredentials) { Endpoint = _connectionString };

            // We need to tell it what types of results we care about
            List<VisualFeatureTypes?> features = new()
            {
                VisualFeatureTypes.Categories,
                VisualFeatureTypes.Description,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Objects,
                VisualFeatureTypes.Adult,
                VisualFeatureTypes.Color,
                VisualFeatureTypes.Faces,
                VisualFeatureTypes.Brands,
                VisualFeatureTypes.ImageType,
                VisualFeatureTypes.Objects
            };

            // Call out to Computer Vision to get the results
            return await vision.AnalyzeImageAsync(imageUrl, features);
        }
    }
}