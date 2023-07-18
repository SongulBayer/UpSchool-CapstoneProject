using FinalProject.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Accounts.Commands.Add
{
    public class AccountAddCommand : IRequest<Response<Guid>>
    {
        public string? Title { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Url { get; set; }
        public bool? IsFavourite { get; set; }
        public string UserId { get; set; }
    }
}
