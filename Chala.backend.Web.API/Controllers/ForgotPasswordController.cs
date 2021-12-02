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

        //[Authorize]
        [HttpPost]
        [Route("GenerateForgotPasswordCode")]
        public IActionResult GenerateForgotPasswordCode([FromBody] string email)
        {
            var res = _forgotPasswordService.GenerateForgotPasswordCode(email);
            if (res)
                return Ok("Code has been generated Successfully");

            return BadRequest("Failed to generate the code");
        }

        [Authorize]
        [HttpPost]
        [Route("CheckForgotPasswordCode")]
        public IActionResult CheckVerificationCodeForEmail([FromBody] ValidateCodeDTOs user)
        {


            var code = _forgotPasswordService.GetAllAsQueryable().Where(x => x.UserId == user.Id && x.Token == user.Code).FirstOrDefault();

            if (code != null)
            {
                if (code.ValidUntil < DateTime.Now)
                    return Conflict("Code is outdated");

            }


            if (_forgotPasswordService.CheckForgotPasswordCode(user.Code, user.Id))
                return Ok("Valid Code");

            return BadRequest("Invalid Code");
        }

    }
}
