using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PlatformService.Data;
using  System.Collections.Generic;
using PlatformService.Dtos;
using System;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repositry;
        private readonly IMapper _mapper;      
        public PlatformsController(IPlatformRepo repositry, IMapper mapper)
        {
            _repositry=repositry;
            _mapper=mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("------>GetPlatform() calling");
            var lstPlatformItems = _repositry.GetAllPlatform();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(lstPlatformItems));
        }
    }
}