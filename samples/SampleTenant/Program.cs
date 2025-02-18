using MadEyeMatt.AspNetCore.Authorization.Permissions;
using MadEyeMatt.AspNetCore.Identity.Permissions;
using MadEyeMatt.AspNetCore.Identity.Permissions.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SampleTenant;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();

builder.Services.AddAuthorization();
builder.Services.AddPermissionsAuthorization();

builder.Services
	.AddAuthentication(IdentityConstants.ApplicationScheme)
	.AddIdentityCookies();

builder.Services
	.AddDbContext<InvoicesContext>(options =>
	{
		options.UseSqlite("Filename=permissions.db");
	})
	.AddPermissionsIdentityCore<IdentityTenant, IdentityTenantUser, IdentityRole, IdentityPermission>(options =>
	{
		options.Password.RequireDigit = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireUppercase = false;
		options.Password.RequiredLength = 6;
		options.Password.RequiredUniqueChars = 0;
	})
	.AddDefaultUI()
	.AddDefaultTokenProviders()
	.AddPermissionClaimsProvider()
	.AddDefaultTenantProvider()
	.AddTenantManager<AspNetTenantManager<IdentityTenant>>()
	.AddUserManager<AspNetUserManager<IdentityTenantUser>>()
	.AddRoleManager<AspNetRoleManager<IdentityRole>>()
	.AddPermissionManager<AspNetPermissionManager<IdentityPermission>>()
	.AddPermissionsEntityFrameworkStores<InvoicesContext>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapRazorPages();
app.Run();
