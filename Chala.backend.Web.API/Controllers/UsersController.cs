using AutoMapper;
using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DB;
using Chala.backend.Infrastructure.Entities.DTOs;
using Chala.backend.Web.API.Authentication;
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
        [Route("Tests")]
        public IActionResult Tests([FromBody] Event eventt)
        {
            return Ok(eventt.Date.ToShortDateString());
        }



        [HttpPost]
        [Route("Authorize")]
        public IActionResult Authorize([FromBody] UserCredintials userCredintials)
        {
            var res = _userService.Authorize(userCredintials.Email, userCredintials.Password);

            if (res.Values.Count == 0)
                return BadRequest("Invalid credintials");

            return Ok(new {id = res["id"],token = res["token"], isVerified = res["isVerified"]});
        }

        [Authorize]
        [HttpGet]
        [Route("IsLoggedIn")]
        public IActionResult IsLoggedIn()
        {
            return Ok();
        }


        [Authorize]
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
                return Conflict("Email already in use!");

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

        [Authorize]
        [HttpPost]
        [Route("EditUserById")]
        public IActionResult EditUserById([FromBody] UserDTOs.Edit dto)
        {
           
            var prevUser = _userService.GetById(dto.Id);

            if (prevUser == null)
                return BadRequest("User does not exist.");

            var newEdittedUser = _mapper.Map<User>(dto);

            if (_userService.Edit(prevUser, newEdittedUser))
                return Ok("User Has been edited.");
            else
                return BadRequest("Failed to edit the user");
        }

        [Authorize]
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

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword([FromBody] ResetPasswordDTOs dto)
        {
            try
            {
                var user = _userService.GetAllAsQueryable().SingleOrDefault(user => user.Email == dto.Email);

                if (_userService.ResetPassword(user, dto.Password)) 
                    return Ok("Password has been updated");

                return BadRequest("Failed to update the password.");
            }
            catch (Exception)
            {
                return BadRequest("Failed to update the password.");
            }

        }


    }
}
