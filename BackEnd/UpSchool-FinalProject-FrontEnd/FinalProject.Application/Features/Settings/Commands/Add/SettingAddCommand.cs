using FinalProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Settings.Commands.Add
{
    public class SettingAddCommand : IRequest<Response<Guid>>
    {
        public string UserId { get; set; }
        public bool SendEmail { get; set; }
        public bool SendNotification { get; set; }
    }
}
