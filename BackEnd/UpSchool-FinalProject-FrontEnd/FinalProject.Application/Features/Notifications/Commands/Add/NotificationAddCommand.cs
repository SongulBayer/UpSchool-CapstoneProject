using FinalProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Notifications.Commands.Add
{
    public class NotificationAddCommand : IRequest<Response<Guid>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsClicked { get; set; }
        public string UserId { get; set; }
    }
}
