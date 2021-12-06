using Chala.backend.Core.IServices;
using Chala.backend.Infrastructure.Entities.DTOs;
using Chala.backend.Web.API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chala.backend.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {


        private readonly IUserService _userService;
        private readonly IForgotPasswordService _forgotPasswordService;

        public ForgotPasswordController(IUserService userService, IForgotPasswordService forgotPasswordService)
        {
            _userService = userService;
            _forgotPasswordService = forgotPasswordService;
        }

        [HttpPost]
        [Route("GenerateForgotPasswordCode")]
        public IActionResult GenerateForgotPasswordCode([FromBody] UserCredintials credintials)
        {
            var res = _forgotPasswordService.GenerateForgotPasswordCode(credintials.Email);
            if (res)
                return Ok("Code has been generated Successfully");

            return BadRequest("Failed to generate the code");
        }

        [HttpPost]
        [Route("CheckForgotPasswordCode")]
        public IActionResult CheckVerificationCodeForEmail([FromBody] ValidateCodeDTOs dto) // EMAIL, CODE
        {

            var user = _userService.GetAllAsQueryable().SingleOrDefault(u => u.Email == dto.Email);

            if (user == null)
                return BadRequest("User doesn't exist.");


            if (_forgotPasswordService.CheckForgotPasswordCode(dto.Code, user))
                return Ok("Valid Code");

            return BadRequest("Invalid Code");
        }

    }
}
