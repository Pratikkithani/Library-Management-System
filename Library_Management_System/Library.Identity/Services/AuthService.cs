using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BooApp.Application.Exceptions;
using BooApp.Application.Interfaces.Identity;
using BooApp.Application.Models.Identity;
using BookApp.Identity.Model;
using Library.Infrastructure.Context;
using LibraryApp.Application.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using LibraryApp.Domain;


namespace BookApp.Identity.Services
{
    internal class AuthService : IAuthService
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManger;
        readonly JwtSettings _jwtSettings;
        readonly LibraryDbContext _libraryDbContext;



        public AuthService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager,IOptions<JwtSettings> jwtSettings,LibraryDbContext libraryDbContext)
        {
            _userManager = userManager; 
            _signInManger = signInManager;
            _jwtSettings = jwtSettings.Value;
            _libraryDbContext = libraryDbContext;
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            if (user == null)
            {
                throw new NotFoundException($"user with Email{authRequest.Email} not exists");
            }
            var userPassword = await _signInManger.CheckPasswordSignInAsync(user, authRequest.Password, false);
            if (userPassword.Succeeded == false)
            {
                throw new BadRequestException($" password Credentials are wrong");
            }

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            var response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
            };
            return response;
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role, roles)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),
                new Claim(ClaimTypes.NameIdentifier,user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials

                );
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new ApplicationUser
            {
                Email = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                UserName = registrationRequest.UserName,
                EmailConfirmed = true
            };
            var member = new Member
            {
                UserId = user.Id,
                Name = registrationRequest.FirstName + registrationRequest.LastName,
                Email = registrationRequest.Email,
                MembershipDate = DateTime.Now,
                Status = registrationRequest.Status

            };
            await _libraryDbContext.Members.AddAsync(member);
            await _libraryDbContext.SaveChangesAsync();
            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationResponse() { UserId = user.Id };

            }
            else
            {
                var errorResult = result.Errors.Select(e => e.Description).ToList();
                throw new BadRequestException($"{errorResult}");
            }

        }
    }
}
