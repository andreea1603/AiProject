using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using WebAPI.Helpers;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using WebAPI.DataModels.Users;
using System.IO;
using WebAPI.DataModels.Admin;
using MongoDB.Bson;
using MongoDB.Driver;
namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public AdminController(
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        [HttpGet("retrain")]
        [Produces("application/json")]
        public IActionResult getListToReview()
        {
            var mongoCollection = MongoService.getToReviewCollection();
            FindOptions<ReevalEntry> options = new FindOptions<ReevalEntry>
            {
                Limit = 10
            }; 
            var commentList = mongoCollection.FindSync(new BsonDocument(), options).ToEnumerable();
            ReevalResponseModel responseModel = new ReevalResponseModel();
            responseModel.Entries = new List<ReevalEntry>();
            foreach (var comment in commentList)
            {
                responseModel.Entries.Add(comment); //intra aici
            }

            return Ok(responseModel.ToJson());  //dar response model=ul ramane tot gol
        }

        [HttpPatch("retrain")]
        public IActionResult addData([FromBody] NewSampleModel newSampleModel)
        {
            if(newSampleModel.tag.Equals("4"))
                AnalysisService.addTrainingData(true, newSampleModel.text);
            else if (newSampleModel.tag.Equals("0"))
                AnalysisService.addTrainingData(false, newSampleModel.text);
            else return BadRequest();
            var mongoCollection = MongoService.getToReviewCollection();
            var deleteFilter = Builders<ReevalEntry>.Filter.Eq("_id", newSampleModel.id);
            mongoCollection.DeleteOne(deleteFilter);
            return Ok();
        }
        [HttpPost("retrain/{time}")]
        public IActionResult retrainReloadModel(int time = 500)
        {
            if(time > 0)
            {
                AnalysisService.retrainModel(time);
                Console.WriteLine("model retrained");
            }
            else
            {
                Console.WriteLine("model training skipped as time is <= 0");
            }
            AnalysisService.reloadModel();
            Console.WriteLine("model reloaded");
            return Ok();
        }
        [HttpPost("retrain")]
        public IActionResult retrainReloadModelDefaultTime()
        {
            AnalysisService.retrainModel();
            Console.WriteLine("model retrained");
            AnalysisService.reloadModel();
            Console.WriteLine("model reloaded");
            return Ok();
        }

        [HttpDelete("retrain/{id}")]
        public IActionResult deleteItemFromDb(string id)
        {
            var mongoCollection = MongoService.getToReviewCollection();
            var deleteFilter = Builders<ReevalEntry>.Filter.Eq("_id", id);
            mongoCollection.DeleteOne(deleteFilter);
            return Ok();
        }
    }
}
