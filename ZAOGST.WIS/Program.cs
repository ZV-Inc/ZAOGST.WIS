global using BlazorTable;
global using FluentValidation;
global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.EntityFrameworkCore;
global using ZAOGST.WIS.Data.DataBaseContext;
global using ZAOGST.WIS.Data.Entities;
global using ZAOGST.WIS.Data.Interfaces;
global using ZAOGST.WIS.Data.Services;
global using ZAOGST.WIS;
global using System.Security.Claims;
global using System.Text.Json;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Mvc;
global using ZAOGST.WIS.Dto;
global using Blazored.LocalStorage;
global using Microsoft.AspNetCore.DataProtection;
global using System.Runtime.Intrinsics.Arm;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
//TODO: Сделать страницу отгрузки

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IControlBlockService, ControlBlockService>();
builder.Services.AddScoped<IBallonService, BallonService>();
builder.Services.AddScoped<IShippedControlBlockService, ShippedControlBlockService>();
builder.Services.AddScoped<IShippedBallonService, ShippedBallonService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddSqlite<DataContext>(@"Data Source=Data\DataBase\ZAOGST.WIS.DataBase.db");
builder.Services.AddBlazorTable();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

//builder.Services.AddDataProtection();
//builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<AuthService>();
//builder.Services.AddAuthentication("cookie")
//	.AddCookie("cookie");

//builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseAuthentication();

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//CreateHostBuilder(args).Build().Run();

//static IHostBuilder CreateHostBuilder(string[] args) =>
//	Host.CreateDefaultBuilder(args)
//	.ConfigureWebHostDefaults(webBuilder =>
//	{
//		webBuilder.UseStartup<StartupBase>();
//		webBuilder.UseUrls("https://*:5001", "http://*:5000");
//	});

//app.Use((ctx, next) =>
//{
//	IDataProtectionProvider idp = ctx.RequestServices.GetRequiredService<IDataProtectionProvider>();
//	IDataProtector protector = idp.CreateProtector("auth-cookie");

//	string? authCookie = ctx.Request.Headers.Cookie.FirstOrDefault(x => x.StartsWith("auth="));
//	string protectedPayload = authCookie.Split("=").Last();
//	string payload = protector.Unprotect(protectedPayload);
//	string[] parts = payload.Split(":");
//	string key = parts[0];
//	string value = parts[1];

//	List<Claim> claims = new()
//	{
//		new(key, value)
//	};

//	ClaimsIdentity identity = new(claims);
//	ctx.User = new(identity);

//	return next();
//});

//app.MapGet("/unsecure", (HttpContext ctx) =>
//{
//	return ctx.User.FindFirst("usr").Value ?? "empty";
//});

////TODO: naming fix
//app.MapGet("/login", (HttpContext ctx) =>
//{
//	//auth.SignIn();

//	List<Claim> claims = new()
//		{
//			new("usr", "Zeerck")
//		};

//	ClaimsIdentity identity = new(claims, "cookie");
//	ClaimsPrincipal user = new(identity);

//	ctx.SignInAsync("cookie", user);
//	return "ok";
//});

app.Run();


//public class AuthService
//{
//	private readonly IDataProtectionProvider _idp;
//	private readonly IHttpContextAccessor _accessor;

//	public AuthService(IDataProtectionProvider idp, IHttpContextAccessor accessor)
//	{
//		_idp = idp;
//		_accessor = accessor;
//	}

//	public void SignIn()
//	{
//		IDataProtector protector = _idp.CreateProtector("auth-cookie");
//		_accessor.HttpContext.Response.Headers["set-cookie"] = $"auth={protector.Protect("usr:Zeerck")}";
//	}
//}