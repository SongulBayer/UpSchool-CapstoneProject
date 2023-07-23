using FinalProject.Application.Common.Interfaces;
using FinalProject.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Application.Features.Orders.Queries.GetById
{
    public  class OrderGetByIdQueryHandler : IRequestHandler<OrderGetByIdQuery, OrderGetByIdDto>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly ICurrentUserService _currentUserService;

        public OrderGetByIdQueryHandler(IApplicationDbContext applicationDbContext, ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }

        public async Task<OrderGetByIdDto> Handle(OrderGetByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _applicationDbContext
                .Orders
                .AsNoTracking()
                .Where(x => x.UserId == _currentUserService.UserId)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            return OrderGetByIdDtoMapper(order);
        }

        private OrderGetByIdDto OrderGetByIdDtoMapper(Order order)
        {
            return new OrderGetByIdDto()
            {
                Id = order.Id,
                RequestedAmount = order.RequestedAmount,
                TotalFoundedAmount = order.TotalFoundedAmount,
                ProductCrowlType = order.ProductCrowlType,
                UserId = order.UserId,
            };
        }
    }
}
