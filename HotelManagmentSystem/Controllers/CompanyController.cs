using Application.Companies.Commands.ActivateCompany;
using Application.Companies.Commands.CreateCompany;
using Application.Companies.Commands.DeactivateCompany;
using Application.Companies.Commands.DeleteCompany;
using Application.Companies.Commands.EditCompany;
using Application.Companies.Dtos;
using Application.Companies.Queries.GetCompanyById;
using Application.Companies.Queries.ShowAllCompaniesInSystem;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HotelManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("CreateCompany")]
        [Authorize(Roles = "User,Admin")]
        public async Task<IActionResult> CreateCompany([FromBody] CompanyDto companyDto)
        {
            companyDto.UserEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)!.Value;
            var result = await _mediator.Send(new CreateCompanyCommand(companyDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllCompaniesInSystem")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllCompaniesInSystem()
        {

            return Ok(await _mediator.Send(new GetAllCompaniesInSystemQuery()));
        }
        [HttpGet("GetCompanyById")]
        [Authorize(Roles = "CompanyAdmin,Admin")]
        public async Task<IActionResult> GetCompanyById(Guid? companyId)
        {
            if (companyId == null)
                companyId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "CompanyId")!.Value);
            var result = await _mediator.Send(new GetCompanyByIdQuery(companyId.Value));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut("EditCompany")]
        [Authorize(Roles = "CompanyAdmin,Admin")]
        public async Task<IActionResult> EditCompany([FromBody] EditCompanyDto editCompanyDto)
        {
            var companyId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "CompanyId")!.Value);
            var result = await _mediator.Send(new EditCompanyCommand(companyId, editCompanyDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPatch("ActivateCompany")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ActivateCompany(Guid companyId)
        {
            var result = await _mediator.Send(new ActivateCompanyCommand(companyId));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPatch("DeactivateCompany")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeactivateCompany(Guid companyId)
        {
            var result = await _mediator.Send(new DeactivateCompanyCommand(companyId));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("DeleteCompany")]
        [Authorize(Roles = "CompanyAdmin,Admin")]
        public async Task<IActionResult> DeleteCompany()
        {
            var companyId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "CompanyId")!.Value);
            var result = await _mediator.Send(new DeleteCompanyCommand(companyId));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }

    }
}
