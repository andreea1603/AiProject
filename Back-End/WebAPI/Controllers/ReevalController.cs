using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebAPI.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Services;
using WebAPI.Entities;
using WebAPI.DataModels.Reevaluation;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReevalController : ControllerBase
    {
        private readonly IReevalService _userService;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public ReevalController(
            IReevalService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;

        }

        [AllowAnonymous]
        [HttpPost("insert")]
        public IActionResult Authenticate([FromBody] InsertReeval model)
        {
            Reeval reeval = new Reeval();
            reeval.Id = model.id;
            reeval.Tweet = model.tweet;
            var user = _userService.Create(reeval);
                //.Authenticate(model.Username, model.Password);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                Tweet = user.Tweet
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetAll(int id)
        {
            int x = id;
            var users = _userService.GetFirstX(x);
            var model = _mapper.Map<IList<Reeval>>(users);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Console.WriteLine("AM INTRAT AICI");

            _userService.Delete(id);
            Console.WriteLine("Am iesit de aici");

            return Ok();
        }
    }
}
