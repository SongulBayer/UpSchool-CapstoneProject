using FinalProject.Application.Features.Accounts.Commands.Add;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using FinalProject.Application.Common.Models.WorkerService;
using FinalProject.Application.Features.Orders.Commands.Add;
using FinalProject.Application.Features.Orders.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace FinalProject.WebApi.Hubs
{
    public class OrderHub:Hub
    {
        private ISender? _mediator;
        private readonly IHttpContextAccessor _contextAccessor;

        public OrderHub(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        protected ISender Mediator => _mediator ??= _contextAccessor.HttpContext.RequestServices.GetRequiredService<ISender>();
        [Authorize]
        public async Task<Guid> AddANewAccount(OrderAddCommand command)
        {
            var accessToken = Context.GetHttpContext().Request.Query["access_token"];

            var result = await Mediator.Send(command);

            var accountGetById = await Mediator.Send(new OrderGetByIdQuery(result.Data));

            await Clients.All.SendAsync("NewOrderAdded", new WorkerServiceNewOrderAddedDto(accountGetById, accessToken));

            return result.Data;
        }
    }
}
