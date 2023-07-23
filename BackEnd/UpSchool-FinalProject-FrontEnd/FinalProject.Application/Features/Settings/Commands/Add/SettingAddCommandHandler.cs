using FinalProject.Application.Common.Interfaces;
using FinalProject.Application.Features.Products.Commands.Add;
using FinalProject.Domain.Common;
using FinalProject.Domain.Entities;
using MediatR;

namespace FinalProject.Application.Features.Settings.Commands.Add
{
    public class SettingAddCommandHandler : IRequestHandler<SettingAddCommand, Response<Guid>>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public SettingAddCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<Response<Guid>> Handle(SettingAddCommand request, CancellationToken cancellationToken)
        {
            var setting = new Setting()
            {
               
            };

            await _applicationDbContext.Settings.AddAsync(setting, cancellationToken);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return new Response<Guid>(" successfully added");
        }
    }
}

