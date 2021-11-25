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
        [Route("GetUserById/{Id}")]
        public IActionResult GetById(Guid Id)
        {

            var res = _userService.GetById(Id);

            if (res == null)
                return BadRequest("User does not exist.");


            return Ok(new { 
            id = res.Id,
            firstName = res.FirstName,
            lastName = res.LastName,
            birthDate = res.Birthdate,
            createDate = res.CreateDate,
            isActive = res.IsActive,
            isVerified = res.IsVerified
            });
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

        [HttpPost]
        [Route("EditUserById/{Id}")]
        public IActionResult EditUserById(Guid Id, [FromBody] UserDTOs.Edit dto)
        {
           
            var prevUser = _userService.GetById(Id);

            if (prevUser == null)
                return BadRequest("User does not exist.");

            var newEdittedUser = _mapper.Map<User>(dto);

            if (_userService.Edit(prevUser, newEdittedUser))
                return Ok("User Has been edited.");
            else
                return BadRequest("Failed to edit the user");
        }


        [HttpPost]
        [Route("DeleteUserById/{Id}")]
        public IActionResult DeleteUserById(Guid Id)
        {
            try
            {
                var user = _userService.GetById(Id);

                if (_userService.Delete(user))
                    return Ok("user has been deleted.");

                return BadRequest("Failed to delete the user.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to delete the user.");
            }

        }


    }
}
