using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PlatformService.Data;
using System.Collections.Generic;
using PlatformService.Dtos;
using PlatformService.Models;
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
            _repositry = repositry;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("------>GetPlatform() calling");
            var lstPlatformItems = _repositry.GetAllPlatform();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(lstPlatformItems));
        }
        [HttpGet("{id}", Name = "GetPlatfomById")]
        public ActionResult<PlatformReadDto> GetPlatfomById(int id)
        {
            var objPlatForm = _repositry.GetPlatformById(id);
            if (objPlatForm != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(objPlatForm));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto objPlatformCreateDto)
        {
            var objPlatform = _mapper.Map<Platform>(objPlatformCreateDto);
            _repositry.CreatePlatform(objPlatform);
            _repositry.SaveChanges();
            var objPlatformReadDto = _mapper.Map<PlatformReadDto>(objPlatform);
            return CreatedAtRoute(nameof(GetPlatfomById), new { Id = objPlatformReadDto.Id }, objPlatformReadDto);
        }
    }
}