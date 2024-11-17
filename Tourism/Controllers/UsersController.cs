﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tourism.Dto;
using Tourism.Services;
using static Tourism.Enums.Enums;

namespace Tourism.Controllers
{
    [Route("")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        //interface config
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // Register
        [HttpPost("SingUp")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var success = await _userService.RegisterAsync(registerDto);

            if (!success)
                return BadRequest("User already exists");

            return Ok("Registration successful");
        }
        [HttpPost("SingIn")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _userService.LoginAsync(loginDto);

            if (token == null)
                return Unauthorized("Invalid credentials");

            return Ok(new { Token = token });
        }
        [Authorize]
        [HttpPut("Edit/profile")]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto updateProfileDto)
        {
            var username = User.Identity.Name;
            var success = await _userService.UpdateProfileAsync(username, updateProfileDto);
            if (!success)
                return BadRequest("could not update profile. please check your data");
            return Ok("Profile updated successfully");
        }
        [Authorize]
        [HttpPost("Article")]
        public async Task<IActionResult> SubmitArticle([FromForm] ArticleDto articleDto)
        {
            var username = User.Identity.Name;

            var result = await _userService.SubmitArticleAsync(username, articleDto);

            if (!result)
                return BadRequest("Could not submit article. Please try again.");

            return Ok("Article submitted successfully");
        
        }
        [HttpGet("Cities")]
        public IActionResult GetCities()
        {
            var cities = Enum.GetValues(typeof(Cities))  
                             .Cast<Cities>()
                             .Select(city => new { Id = (int)city, Name = city.ToString() })
                             .ToList();

            return Ok(cities); 
        }
        [HttpGet("GetTopics")]
        public IActionResult GetTopics()
        {
            var topics = Enum.GetValues(typeof(ArticleTopic))
                             .Cast< ArticleTopic>()
                             .Select(topic => new { Id = (int)topic, Name = topic.ToString() })
                             .ToList();

            return Ok(topics);
        }

    }
}
