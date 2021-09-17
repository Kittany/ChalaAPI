using AutoMapper;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Chala.backend.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {

            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Authorize")]
        public IActionResult Authorize([FromBody] UserCredintials userCredintials)
        {
            var res = _userService.Authorize(userCredintials.Email, userCredintials.Password);

            if (string.IsNullOrEmpty(res))
                return BadRequest("Invalid credintials");

            return Ok(res);
        }


        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(Guid Id)
        {
            return Ok(_userService.GetById(Id));
        }



        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] UserDTOs.Create dto)
        {

            if (_userService.GetAllAsQueryable().Any(x => x.Email.Equals(dto.Email)))
                return BadRequest("Email already in use!");

            try
            {
                var user = _mapper.Map<User>(dto);


                var res = _userService.Create(user);

                if (res)
                    return Ok("Account created successfully!");


                return BadRequest("Something went wrong!");
            }
            catch
            {
                return BadRequest("Something went wrong!");
            }


        }


    }
}
