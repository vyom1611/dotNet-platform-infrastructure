using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> getPlatforms()
    {
        Console.WriteLine("--> Getting Platforms...");
        var platformItems = _repository.getAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }
    
    [HttpGet("{id}", Name = "getPlatformById")]
    public ActionResult<PlatformReadDto> getPlatformById(int id)
    {
        Console.WriteLine("--> Getting Platform by id...");
        var platformItem = _repository.getPlatformById(id);
        if (!platformItem.Equals(null))
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        return NotFound();
    }
    
    [HttpPost("{platformCreateDto}", Name = "CreatePlatform")]
    [Route("/CreatePlatform/{platformCreateDto}")]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        Console.WriteLine("--> Creating Platform...");
        var platformModel = _mapper.Map<Platform>(platformCreateDto);
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();
        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
        return CreatedAtRoute(nameof(getPlatformById), new {Id = platformReadDto.Id}, platformReadDto);
    }

    [HttpDelete("{id}", Name = "DeletePlatform")]
    [Route("/DeletePlatform/{id:int}")]
    public ActionResult<PlatformReadDto> DeletePlatform(int id)
    {
        Console.Write("--> Deleting Platform...");
        var platformModel = _repository.getPlatformById(id);
        if (platformModel.Equals(null))
        {
            return NotFound();
        }
        _repository.DeletePlatform(id);
        _repository.SaveChanges();
        return NoContent();
    }
}