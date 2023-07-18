
using FinalProject.Application.Common.Interfaces;
using FinalProject.Domain.Common;
using FinalProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.Accounts.Commands.Add
{
    public class AccountAddCommandHandler : IRequestHandler<AccountAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public AccountAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(AccountAddCommand request, CancellationToken cancellationToken)
        {
            var account = AccountAddCommandMapper(request);

            await _applicationDbContext.Accounts.AddAsync(account, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(/*_localizer[CommonLocalizationKeys.HandlerMessages.Add]*/"", account.Id);
        }

        private Account AccountAddCommandMapper(AccountAddCommand command)
        {
            var id = Guid.NewGuid();

            return new Account()
            {
                Id = id,
                Title = command.Title,
                UserName = command.UserName,
                Password = command.Password,
                Url = command.Url,
                IsFavourite = command.IsFavourite,
                CreatedOn = DateTimeOffset.Now,
            };
        }
    }
}
