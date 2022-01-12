using Microsoft.AspNetCore.Mvc;
using SentiTweet.DataModels;
using Microsoft.Extensions.ML;
using System;
using Microsoft.ML;
using System.IO;

using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("v1/analysis")]  
    [ApiController]  
    public class AnalysisController : ControllerBase  
    {

        private readonly static MLContext mlContext = new MLContext();
        public readonly static PredictionEngine<ModelInput, ModelOutput> predictionEngine =
            mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(
                mlContext.Model.Load(Path.GetFullPath("MLModel.zip"), out _)
                );
        
        public AnalysisController()
        {
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] ModelInput data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(AnalysisService.Predict(data).Prediction);
        }

        [HttpGet]
        public ActionResult<int> Get([FromQuery] ModelInput modelInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return Ok(AnalysisService.Predict(modelInput).Prediction);
        }
    }
}  