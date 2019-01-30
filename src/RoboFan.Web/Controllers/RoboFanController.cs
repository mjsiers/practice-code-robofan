using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoboFan.Data.Mock.Generators;
using RoboFan.Domain.Converters;
using RoboFan.Domain.Repositories;
using RoboFan.Domain.ViewModels;
using Serilog;

namespace RoboFan.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoboFanController : ControllerBase
  {
    private readonly ILogger _log = Log.ForContext<RoboFanController>();
    private readonly IRoboFanRepository _roboFanRepository;
    private readonly IRoboFanImageRepository _roboFanImageRepository;

    public RoboFanController(IRoboFanRepository robofan, IRoboFanImageRepository robofanimage)
    {
      _roboFanRepository = robofan;
      _roboFanImageRepository = robofanimage;
    }

    [HttpGet("")]
    [Produces(typeof(List<RoboFanViewModel>))]
    public async Task<IActionResult> Get(CancellationToken ct = default)
    {
      try
      {
        var listfans = await _roboFanRepository.GetAllAsync(ct);
        if (listfans == null)
        {
          return NotFound();
        }

        var listmodels = RoboFanConverter.ConvertList(listfans);
        return Ok(listmodels);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpGet("{id}")]
    [Produces(typeof(RoboFanViewModel))]
    public async Task<IActionResult> Get(int id, CancellationToken ct = default)
    {
      try
      {
        var robofan = await _roboFanRepository.GetByIdAsync(id, ct);
        if (robofan == null)
        {
          return NotFound();
        }

        var model = RoboFanConverter.Convert(robofan);
        return Ok(model);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpGet("{id}/image")]
    public async Task<IActionResult> GetImage(int id, CancellationToken ct = default)
    {
      try
      {
        var fanimage = await _roboFanImageRepository.GetByIdAsync(id, ct);
        if (fanimage == null)
        {
          return NotFound();
        }

        // return the requested robofan image data
        return File(fanimage.ImageData, fanimage.ContentType);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpPost("generate")]
    public async Task<IActionResult> PostGenerate([FromBody]int numfans, CancellationToken ct = default)
    {
      try
      {
        if ((numfans <= 0) || (numfans > 10))
          return BadRequest();

        var listfans = await RoboFanGenerator.GenerateAsync(numfans);
        var status = await _roboFanRepository.AddManyAsync(listfans, ct);
        return StatusCode(201, status);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }
  }
}
