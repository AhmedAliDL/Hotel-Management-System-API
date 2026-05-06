using Application.Subscriptions.Commands.CreateSubscription;
using Application.Subscriptions.Commands.EditSubscription;
using Application.Subscriptions.Dtos;
using Application.Subscriptions.Queries.GetAllActiveSubscription;
using Application.Subscriptions.Queries.GetAllSubscription;
using Application.Subscriptions.Queries.GetSubscriptionDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubscriptionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Subscribe")]
        [Authorize(Roles = "CompanyAdmin,Admin")]
        public async Task<IActionResult> Subscribe(SubscriptionDto subscriptionDto)
        {
            var companyIdValue = User.Claims.FirstOrDefault(c => c.Type == "CompanyId")?.Value;
            if (!Guid.TryParse(companyIdValue, out var companyId))
                return BadRequest("You can only subscribe for your own company.");
            subscriptionDto.CompanyId = companyId;
            var result = await _mediator.Send(new CreateSubscriptionCommand(subscriptionDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetAllSubscription")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllSubscription()
        {
            return Ok(await _mediator.Send(new GetAllSubscriptionQuery()));
        }
        [HttpGet("GetAllActiveSubscription")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllActiveSubscription()
        {
            return Ok(await _mediator.Send(new GetAllActiveSubscriptionQuery()));
        }

        [HttpGet("GetSubscriptionDetails")]
        [Authorize(Roles = "CompanyAdmin,Admin")]
        public async Task<IActionResult> GetSubscriptionDetails(Guid? companyId)
        {
            if (companyId == null)
                companyId = Guid.Parse(User.Claims.FirstOrDefault(c => c.Type == "CompanyId")!.Value);

            return Ok(await _mediator.Send(new GetSubscriptionDetailsQuery(companyId.Value)));
        }
        [HttpPost("ChangeSubscription")]
        [Authorize(Roles = "CompanyAdmin,Admin")]
        public async Task<IActionResult> ChangeSubscription(SubscriptionDto subscriptionDto)
        {
            var companyIdValue = User.Claims.FirstOrDefault(c => c.Type == "CompanyId")?.Value;
            if (!Guid.TryParse(companyIdValue, out var companyId))
                return BadRequest("You can only subscribe for your own company.");
            subscriptionDto.CompanyId = companyId;
            var result = await _mediator.Send(new EditSubscriptionCommand(subscriptionDto));
            if (!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
