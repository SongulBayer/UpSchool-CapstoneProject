using FinalProject.Application.Common.Interfaces;
using FinalProject.Domain.Common;
using MediatR;

namespace FinalProject.Application.Features.Notifications.Commands.Update
{
    public class NotificationUpdateCommandHandler : IRequestHandler<NotificationUpdateCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public NotificationUpdateCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(NotificationUpdateCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Notifications
            .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new Exception();
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.IsClicked = request.IsClicked;
            entity.UserId = request.UserId;

            await _applicationDbContext.SaveChangesAsync(cancellationToken);
            return new Response<Guid>($"The notification was successfully updated.", entity.Id);
        }
    }
}
