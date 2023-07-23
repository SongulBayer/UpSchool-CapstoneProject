using FinalProject.Application.Common.Interfaces;
using FinalProject.Application.Common.Models.Auth;
using FinalProject.Domain.Identity;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Services
{
    public class AuthenticationManager : IAuthenticationService
    {
        //Identity kütüphanesinden gelen bir method.
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public AuthenticationManager(UserManager<User> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }


        public  Task<bool> CheckIfUserExists(string email, CancellationToken cancellationToken)
        {
            return _userManager.Users.AnyAsync(x => x.Email == email, cancellationToken);
        }

        public async Task<string> CreateUserAsync(CreateUserDto createUserDto, CancellationToken cancellationToken)
        {
           var user=createUserDto.MapToUser();
            //Kullanıcıyı şifresiz oluşturabiliriz. Şifresi google ya da facebook ile login yaparsa kllanıcıyı şifresiz login edebiliyoruz.
           var identityResult=await _userManager.CreateAsync(user, createUserDto.Password);
            if (!identityResult.Succeeded)
            {
                //select her bir erroru seçmemize yarayacak
                //select foreach gibi çalışır ve her identity erroru tek tek seçer.
              var  failures = identityResult.Errors
                    .Select(x => new ValidationFailure(x.Code, x.Description));

                throw new ValidationException(failures);
             }

            return user.Id;
        }

        public async Task<string> GenerateEmailActivationTokenAsync(string userId, CancellationToken cancellationToken)
        {
           var user = await _userManager.FindByIdAsync(userId);
           return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<JwtDto> SocialLoginAsync(string email, string firstName, string lastName, CancellationToken cancellationToken)
        {
            //Kullanıcı varsa kullanıcı üzerinden jwt token üretilecek
            //kullanıcı yoksa yeni kullanıcı kaydetip sonra jwt dönüyoruz
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null)
                return _jwtService.Generate(user.Id, user.Email, user.FirstName, user.LastName);
            var userId = Guid.NewGuid().ToString();

            user = new User()
            {
                Id = userId,
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                FirstName = firstName,
                LastName = lastName,
                CreatedOn = DateTimeOffset.Now,
                CreatedByUserId = userId,
            };
            var identityResult = await _userManager.CreateAsync(user);

            if (!identityResult.Succeeded)
            {
                var failures = identityResult.Errors
                    .Select(x => new ValidationFailure(x.Code, x.Description));

                throw new ValidationException(failures);
            }

            return _jwtService.Generate(user.Id, user.Email, user.FirstName, user.LastName);
        }
    }
}
