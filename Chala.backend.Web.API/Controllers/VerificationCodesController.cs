using AutoMapper;
using Chala.backend.Core.IServices;
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
    public class VerificationCodesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IVerificationCodesService _verificationCodesService;

        public VerificationCodesController(IMapper mapper, IVerificationCodesService verificationCodesService)
        {
            _mapper = mapper;
            _verificationCodesService = verificationCodesService;
        }
        [HttpGet]
        [Route("GetVerificationCodeById/{Id}")]
        public IActionResult GetVerificationCodeById(Guid Id)
        {
            var verificationCode = _verificationCodesService.GetById(Id);
            if (verificationCode != null)
                return Ok(verificationCode);

            return BadRequest("Invalid code.");
        }

        //[Authorize]
        [HttpPost]
        [Route("GenerateVerificationCodeForEmail")]
        public IActionResult GenerateVerificationCodeForEmail([FromBody] string email)
        {
            var res = _verificationCodesService.GenerateVerificationCodeForEmail(email);
            if (res)
                return Ok("Code has been generated Successfully");

            return BadRequest("Failed to generate the code");
        }

        [HttpPost]
        [Route("CheckVerificationCodeForEmail")]
        public IActionResult CheckVerificationCodeForEmail([FromBody] UserVerificationCodeAndEmail user)
        {

            if (_verificationCodesService.CheckVerificationCodeForEmail(user.Code, user.Email))
                return Ok("Valid Code");

            return BadRequest("Invalid Code");
        }

    }

    public class UserVerificationCodeAndEmail
    {
        public string Code { get; set; }
        public string Email { get; set; }
    };
}
