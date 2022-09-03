using Core.Application.Requests;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Models;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage;
using Kodlama.io.devs.Application.Features.ProgrammingLanguages.Queries.ListProgrammingLanguage;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.devs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammingLanguagesController : BaseController
    {
        public ProgrammingLanguagesController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get(int page, int pageSize)
        {
            ListProgrammingLanguageQuery listProgrammingLanguageQuery = new()
            {
                PageRequest = new PageRequest { Page = page, PageSize = pageSize }
            };

            ProgrammingLanguageListModel model = await Mediator.Send(listProgrammingLanguageQuery);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            GetByIdProgrammingLanguageDto getByIdProgrammingLanguageDto = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(getByIdProgrammingLanguageDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto createdProgrammingLanguageDto = await Mediator.Send(createProgrammingLanguageCommand);
            return Ok(createdProgrammingLanguageDto);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(updatedProgrammingLanguageDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(deletedProgrammingLanguageDto);
        }
    }
}
