using IdentityDemo.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDemo.Application.Users;

public interface IIdentityUserService
{
    Task<UserResultDto> CreateUserAsync(UserProfileDto user, string password);
    Task<UserResultDto> SignInAsync(string email, string password);
    Task SignOutAsync();
    Task<UserProfileDto> GetUserByNameAsync(string name);
}
