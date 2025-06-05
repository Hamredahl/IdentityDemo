using IdentityDemo.Application.Users;
using IdentityDemo.Infrastructure.Persistence;
using IdentityDemo.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllersWithViews();
        builder.Services.AddTransient<IUserService, UserService>();
        builder.Services.AddTransient<IIdentityUserService, IdentityUserService>();

        builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
        })
        .AddEntityFrameworkStores<ApplicationContext>()
        .AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(o => o.LoginPath = "/login");

        // Konfigurera EF
        builder.Services.AddDbContext<ApplicationContext>(
            o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.MapControllers();

        app.Run();
    }
}