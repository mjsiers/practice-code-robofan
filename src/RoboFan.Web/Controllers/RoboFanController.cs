﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RoboFan.Data.Mock.Generators;
using RoboFan.Domain.Converters;
using RoboFan.Domain.Repositories;
using RoboFan.Domain.ViewModels;
using RoboFan.Web.Filters;
using Serilog;

namespace RoboFan.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RoboFanController : ControllerBase
  {
    private readonly ILogger _log = Log.ForContext<RoboFanController>();
    private IHostingEnvironment _hostingEnvironment;
    private readonly IRoboFanRepository _roboFanRepository;
    private readonly IRoboFanImageRepository _roboFanImageRepository;

    public RoboFanController(IHostingEnvironment environment, IRoboFanRepository robofan, IRoboFanImageRepository robofanimage)
    {
      _hostingEnvironment = environment;
      _roboFanRepository = robofan;
      _roboFanImageRepository = robofanimage;
    }

    [HttpGet("")]
    [Produces(typeof(List<RoboFanViewModel>))]
    public async Task<IActionResult> Get(CancellationToken ct = default)
    {
      try
      {
        // fetch all the records
        // todo: support paging
        var listfans = await _roboFanRepository.GetAllAsync(ct);
        if (listfans == null)
        {
          return NotFound();
        }

        // determine the full host URL string
        var hostpath = string.Format("{0}://{1}", Request.Scheme, Request.Host.ToString());
        _log.Information("Get: HostPath[{0}]", hostpath);

        // convert records into the correct format for the client
        var listmodels = RoboFanConverter.ConvertList(listfans, hostpath);
        return Ok(listmodels);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpGet("search")]
    [Produces(typeof(List<RoboFanViewModel>))]
    public async Task<IActionResult> Get(string namefilter="", CancellationToken ct = default)
    {
      try
      {
        // fetch all the records
        // todo: support paging
        var listfans = await _roboFanRepository.GetAllFilterAsync(namefilter, ct);
        if (listfans == null)
        {
          return NotFound();
        }

        // determine the full host URL string
        var hostpath = string.Format("{0}://{1}", Request.Scheme, Request.Host.ToString());
        _log.Information("Get: HostPath[{0}]", hostpath);

        // convert records into the correct format for the client
        var listmodels = RoboFanConverter.ConvertList(listfans, hostpath);
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
        // get the specified record
        var robofan = await _roboFanRepository.GetByIdAsync(id, ct);
        if (robofan == null)
        {
          return NotFound();
        }

        // convert record into the correct format for the client
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
        // get the specified record
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

    [HttpPost("create")]
    public async Task<IActionResult> PostCreate([FromBody]RoboFanCreate create, CancellationToken ct = default)
    {
      try
      {
        // determine the robot image path
        _log.Information("PostCreate: [{0} {1}]", create.FirstName, create.LastName);
        var rootpath = _hostingEnvironment.WebRootPath;
        var robopath = System.IO.Path.Combine(rootpath, "images/robots");

        // generate a random fan and overide values received from this post request
        // todo: look into setting up automapper?
        var listfans = await RoboFanGenerator.GenerateAsync(1, robopath, true);
        if (!string.IsNullOrEmpty(create.FirstName))
        {
          listfans[0].FirstName = create.FirstName;
        }
        if (!string.IsNullOrEmpty(create.LastName))
        {
          listfans[0].LastName = create.LastName;
        }
        if (!string.IsNullOrEmpty(create.Address))
        {
          listfans[0].Address = create.Address;
        }
        if (!string.IsNullOrEmpty(create.City))
        {
          listfans[0].City = create.City;
        }
        if (!string.IsNullOrEmpty(create.State))
        {
          listfans[0].State = create.State;
        }

        // add the new fan to the databasse
        var status = await _roboFanRepository.AddManyAsync(listfans, ct);
        return StatusCode(201, status);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpPost("generate")]
    public async Task<IActionResult> PostGenerate([FromBody]RoboFanGenerate generate, CancellationToken ct = default)
    {
      try
      {
        // ensure input values are valid
        _log.Information("PostGenerate: [{0}]", generate.Num);
        if ((generate.Num <= 0) || (generate.Num > 10))
          return BadRequest();

        // determine the robot image path and generate the requested number of fans
        var rootpath = _hostingEnvironment.WebRootPath;
        var robopath = System.IO.Path.Combine(rootpath, "images/robots");
        var listfans = await RoboFanGenerator.GenerateAsync(generate.Num, robopath, true);
        var status = await _roboFanRepository.AddManyAsync(listfans, ct);
        return StatusCode(201, status);
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }

    [HttpPost("delay")]
    public IActionResult PostDelay([FromBody]RoboFanDelay delay, CancellationToken ct = default)
    {
      try
      {
        // ensure input values are valid
        _log.Information("PostDelay: [min:{0} max:{1}]", delay.Min, delay.Max);
        if ((delay.Min < 0) || (delay.Max <  0))
        {
          _log.Warning("PostDelay: Values must be positive");
          return BadRequest();
        }
        else if ((delay.Min > 5) || (delay.Max > 5))
        {
          _log.Warning("PostDelay: Values must be <= 5");
          return BadRequest();
        }
        else if (delay.Min > delay.Max)
        {
          _log.Warning("PostDelay: Min must be <= Max");
          return BadRequest();
        }

        // update the response delay values
        // todo: provide a way for the client to query and get the current delay values
        DelayResponseFilter.SetResponseDelay(delay.Min, delay.Max);
        return Ok();
      }
      catch (Exception ex)
      {
        return StatusCode(500, ex);
      }
    }
  }
}
