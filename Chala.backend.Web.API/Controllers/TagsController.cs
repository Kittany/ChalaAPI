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
        public TagsController(IMapper mapper)
        {
            //_mapper = mapper;
        }
        [HttpGet]
        [Route("GetAllTags/{Id}")]
        public IActionResult GetAllTags(Guid id)
        {
            var res = _tagService.GetAllAsQueryable().ToList();
            return Ok(res);
        }

    }
}
