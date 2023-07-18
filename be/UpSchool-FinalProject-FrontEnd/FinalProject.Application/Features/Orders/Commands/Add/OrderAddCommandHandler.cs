using FinalProject.Application.Common.Interfaces;
using FinalProject.Application.Common.Localizations;
using FinalProject.Application.Features.Products.Commands.Add;
using FinalProject.Domain.Common;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Enums;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject.Application.Features.Orders.Commands.Add
{
    public class OrderAddCommandHandler : IRequestHandler<OrderAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        private readonly ICurrentUserService _currentUserService;
        private readonly IStringLocalizer<CommonLocalizations> _localizer;

        public OrderAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(OrderAddCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var order = new Order()
            {
                Id =id,
                RequestedAmount = request.RequestedAmount,
                TotalFoundedAmount = request.TotalFoundedAmount,
                ProductCrowlType = request.ProductCrowlType,
                CreatedOn = DateTimeOffset.Now,
                UserId = _currentUserService.UserId
            };

            await _applicationDbContext.Orders.AddAsync(order, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(_localizer[CommonLocalizationKeys.HandlerMessages.Add], order.Id);
        }
    }
}
