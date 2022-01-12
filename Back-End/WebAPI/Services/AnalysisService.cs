using Microsoft.ML;
using SentiTweet.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static Microsoft.ML.DataOperationsCatalog;
using Microsoft.ML.Data;
using WebAPI.Controllers;
using System.Threading;

namespace WebAPI.Services {
    public class AnalysisService : IAnalysisService {   
        private static Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictionEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);
        public readonly static string MLNetModelPath = Environment.CurrentDirectory + "\\MLModel.zip";
        private readonly static string trainingSetPath = Environment.CurrentDirectory + "\\trainingset.csv";
        private readonly static string mlModelOutputPath = Environment.CurrentDirectory + "\\SampleClassification\\SampleClassification.Model\\MLModel.zip";
        private readonly static string mlModelOutputProblematicFile1 = Environment.CurrentDirectory + "\\SampleClassification\\SampleClassification.ConsoleApp\\ModelBuilder.cs";
        private readonly static string mlModelOutputProblematicFile2 = Environment.CurrentDirectory + "\\SampleClassification\\SampleClassification.ConsoleApp\\Program.cs";

        public static ModelOutput Predict(ModelInput input)
        {
            ModelOutput result = PredictionEngine.Value.Predict(input);
            return result;
        }

        public static PredictionEngine<ModelInput, ModelOutput> CreatePredictionEngine()
        {
            MLContext mlContext = new MLContext();
            ITransformer mlModel;
            mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
            return predEngine;
        }
        public static SentimentPrediction PredictionStatistics(ModelInput modelInput)
        {
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = modelInput.Col5
            };
            MLContext mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(mlModel);
            var resultPrediction = predictionFunction.Predict(sampleStatement);
            return resultPrediction;
        }

        public static float[] SentimentPredictionProbability(ModelInput modelInput)
        {
            var predictionEngineScore = AnalysisController.predictionEngine;
            var modelOutput = predictionEngineScore.Predict(modelInput);

            var labelBuffer = new VBuffer<ReadOnlyMemory<char>>();
            predictionEngineScore.OutputSchema["Score"].Annotations.GetValue("SlotNames", ref labelBuffer);
            var labels = labelBuffer.DenseValues().Select(l => l.ToString()).ToArray();

            var index = Array.IndexOf(labels, modelOutput.Prediction);
            var score = modelOutput.Score[index];
            float[] array = new float[5];
            array[0] = int.Parse(modelOutput.Prediction);
            array[1] = score;
            return array;
        }


        public static void addTrainingData(bool isPositive, string tweetText)
        {
            string col0;
            if (isPositive)
                col0 = "\"4\"";
            else
                col0 = "\"0\"";

            string col1 = "\"1467810369\"";
            string col2 = "\"Mon Apr 06 22:19:45 PDT 2009\"";
            string col3 = "\"NO_QUERY\"";
            string col4 = "\"username\"";
            string col5 = "\"" + tweetText + "\""; //text
            using (StreamWriter sw = File.AppendText(trainingSetPath))
            {
                sw.WriteLine(col0 + "," + col1 + "," + col2 + "," + col3 + "," + col4 + "," + col5);
            }
        }

        public static void reloadModel()
        {
            Lazy<PredictionEngine<ModelInput, ModelOutput>> tempPredEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(CreatePredictionEngine);
            Interlocked.Exchange(ref PredictionEngine, tempPredEngine);
        }

        public static void retrainModel(int time = 500)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "mlnet";
            startInfo.Arguments = "classification --dataset \"trainingset.csv\" --label-col 0 --has-header false --train-time "+ time +" -o " + Environment.CurrentDirectory;
            process.StartInfo = startInfo;
            Console.WriteLine("retraining started");
            try
            {
                process.Start();
                process.WaitForExit();
            }
            catch
            {
                Console.WriteLine("have you installed mlnet? use dotnet tool install -g mlnet");
            }
            if (!File.Exists(mlModelOutputPath))
            {
                Console.WriteLine("training failed, keeping old model");
                return;
            }
            if(File.Exists(MLNetModelPath))
                File.Delete(MLNetModelPath);
            File.Copy(mlModelOutputPath, MLNetModelPath);
            for(int i = 0; i < 10; i++)
            {
                try
                {
                    File.Delete(mlModelOutputProblematicFile1); //am incercat sa sterg folder-ul dar nu merge, asa ca am sters fisierele
                    File.Delete(mlModelOutputProblematicFile2); // din el si am adaugat folderul la ignore in proiect, in webAPI.csproj
                }
                catch (System.UnauthorizedAccessException)
                {
                    Thread.Sleep(500);
                    continue;
                }
            }
            if(File.Exists(mlModelOutputProblematicFile2) || File.Exists(mlModelOutputProblematicFile1))
                Console.WriteLine("some files were not deleted. this may cause problem on the next build");
            Console.WriteLine("retraining finished");
        }

    }

}