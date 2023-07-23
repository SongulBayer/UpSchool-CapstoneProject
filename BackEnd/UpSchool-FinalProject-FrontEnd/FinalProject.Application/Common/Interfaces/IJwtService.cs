using FinalProject.Application.Common.Models.Auth;

namespace FinalProject.Application.Common.Interfaces
{
    public interface IJwtService
    {
        JwtDto Generate(string userId,string email,string firstName,string lastName, List<string>? roles = null);
    }
}
