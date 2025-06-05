using IdentityDemo.Application.Dtos;
using IdentityDemo.Application.Users;
using IdentityDemo.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDemo.Infrastructure.Services;
public class IdentityUserService
(
    UserManager<ApplicationUser> userManager, 
    SignInManager<ApplicationUser> signInManager
) : IIdentityUserService
{
    public async Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password)
    {
        ApplicationUser applicationUser = new ApplicationUser
        {
            UserName = user.Email,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            FavouriteColour = user.FavouriteColour
        };
        var result = await userManager.CreateAsync(applicationUser, password);
        await userManager.AddClaimAsync(applicationUser, new Claim("SpokenName", applicationUser.FirstName));

        return new UserResultDto(result.Errors.FirstOrDefault()?.Description);
    }

    public async Task<UserResultDto> SignInAsync(string email, string password)
    {
        SignInResult result = await signInManager.PasswordSignInAsync(email, password, false, false);
        return new UserResultDto(result.Succeeded ? null : "Invalid user credentials");
    }

    public async Task SignOutAsync()
    {
        await signInManager.SignOutAsync();
    }
}
