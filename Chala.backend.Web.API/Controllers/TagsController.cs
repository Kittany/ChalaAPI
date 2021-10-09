using AutoMapper;
using Chala.backend.Core.IServices;
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
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        // We dont need Mapper for now
        //private readonly IMapper _mapper;
        public TagsController(IMapper mapper, ITagService tagService)
        {
            _tagService = tagService;
            //_mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllTags")]
        public IActionResult GetAllTags()
        {
            var res = _tagService.GetAllAsQueryable();
            return Ok(res);
        }
        [HttpGet]
        [Route("GetById/{Id}")]
        public IActionResult GetById(Guid Id)
        {
            var res = _tagService.GetById(Id);
            if (res != null)
                return Ok(res);
            else
                return BadRequest("User not found.");
        }


    }
}
