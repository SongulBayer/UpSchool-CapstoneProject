using FinalProject.Application.Common.Interfaces;
using FinalProject.Domain.Common;
using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.Notifications.Commands.Add
{
    public class NotificationAddCommandHandler : IRequestHandler<NotificationAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public NotificationAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(NotificationAddCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification()
            {
               Title = request.Title,
               Description = request.Description,
               IsClicked = request.IsClicked,
               CreatedOn = DateTime.Now
            };


            await _applicationDbContext.Notifications.AddAsync(notification, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>($"Notification successfully added.");
        }
    }
}
