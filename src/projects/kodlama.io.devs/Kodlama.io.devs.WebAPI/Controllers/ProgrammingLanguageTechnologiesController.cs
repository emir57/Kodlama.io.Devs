﻿using Core.Application.Requests;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.CreateProgrammingLanguageTechnology;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Commands.UpdateProgrammingLangaugeTechnology;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Models;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.GetByIdProgrammingLanguageTechnology;
using Kodlama.io.devs.Application.Features.ProgrammingLanguageTechnologies.Queries.ListProgrammingLanguageTechnology;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgrammingLanguageTechnologiesController : BaseController
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageRequest pageRequest)
    {
        ListProgrammingLanguageTechnologyQuery request = new() { PageRequest = pageRequest };
        ProgrammingLanguageTechnologyListModel result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] GetByIdProgrammingLanguageTechnologyQuery request)
    {
        GetByIdProgrammingLanguageTechnologyDto result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProgrammingLanguageTechnologyCommand request)
    {
        CreatedProgrammingLanguageTechnologyDto result = await Mediator.Send(request);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateProgrammingLanguageTechnologyCommand request)
    {
        UpdatedProgrammingLanguageTechnologyDto result = await Mediator.Send(request);
        return Ok(result);
    }
}
