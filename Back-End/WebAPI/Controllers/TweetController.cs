using Microsoft.AspNetCore.Mvc;
using SentiTweet.DataModels;
using Microsoft.Extensions.ML;
using System;
using Newtonsoft.Json.Linq;
using SentiTweet.Services;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("v1/hashtagAnalysis")]
    [ApiController]
    public class TweetController : ControllerBase
    {
        public TweetController() { }

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
        [Produces("application/json")]
        public ActionResult<String[]> Get([FromQuery] String modelInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            TweetService client = new TweetService();

            var result = client.GetPostByHashtagAsync(modelInput);

            ModelInput modelInput1 = new ModelInput();
            string[] allInformation = new string[100];

            try
            {
                modelInput1.Col5 = result.Result[0].Text; 
            }
            catch
            {
                allInformation[0] = "Numarul de negative " + 0;
                allInformation[1] = "Numarul de pozitive " + 0;
                return UnprocessableEntity(allInformation); //daca nu sunt twetts, crapa inainte
            }

            int numberOfPositives = 0, numberOfNegative = 0;

            int n = 1, p = 30;

            for (int i = 0; i < result.Result.Length; i++)
            {
                modelInput1.Col5 = result.Result[i].Text;

                float[] predict = AnalysisService.SentimentPredictionProbability(modelInput1);

                if (predict[0] == 0)
                {

                    numberOfNegative++;
                    if (n < 29 && predict[1] > 0.95)
                    {
                        n++;
                        allInformation[n] = result.Result[i].Text;
                    }
                }
                else
                {
                    numberOfPositives++;
                    if (p < 99 && predict[1] > 0.95)
                    {
                        p++;
                        allInformation[p] = result.Result[i].Text;
                    }
                }
            }
            allInformation[0] = "Numarul de negative " + numberOfNegative.ToString();
            allInformation[1] = "Numarul de pozitive " + numberOfPositives.ToString();

            return Ok(allInformation);
        }
    }
}