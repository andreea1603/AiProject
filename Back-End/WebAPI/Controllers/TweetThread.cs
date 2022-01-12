using Microsoft.AspNetCore.Mvc;
using SentiTweet.DataModels;
using Microsoft.Extensions.ML;
using System;
using Newtonsoft.Json.Linq;
using SentiTweet.Services;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("v1/ThreadAnalysis")]
    [ApiController]
    public class TweetThreadController : ControllerBase
    {
        public TweetThreadController() { }

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

            var result = client.getRetweets(modelInput);

           
            ModelInput modelInput1 = new ModelInput();
            modelInput1.Col5 = result[0];

            Console.WriteLine(result);
            int numberOfPositives = 0, numberOfNegative = 0;
            string[] allInformation = new string[100];

            int n = 1, p = 30;
            Console.WriteLine(result.Length);
            for (int i = 0; i < result.Length && !string.IsNullOrEmpty(result[i]); i++)
            {
                Console.WriteLine("Rezultatul de la iteratia i");
                Console.WriteLine(result[i]);

                modelInput1.Col5 = result[i];

                float[] predict = AnalysisService.SentimentPredictionProbability(modelInput1);


                if (predict[0] == 0)
                {

                    numberOfNegative++;
                    Console.WriteLine("Numarul de negative este: ");
                    Console.WriteLine(numberOfNegative);
                    if (n < 29 && predict[1] > 0.95)
                    {
                        n++;
                        allInformation[n] = result[i];
                    }
                }
                else
                {
                    numberOfPositives++;
                    Console.WriteLine("Numarul de pozitive este: ");
                    Console.WriteLine(numberOfPositives);

                    if (p < 99 && predict[1] > 0.95)
                    {
                        p++;
                        allInformation[p] = result[i];
                    }
                }
            }
            allInformation[0] = "Numarul de negative " + numberOfNegative.ToString();
            allInformation[1] = "Numarul de pozitive " + numberOfPositives.ToString();

            return Ok(allInformation);
        }
    }
}
