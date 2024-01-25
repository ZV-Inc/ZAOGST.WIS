global using Blazored.LocalStorage;
global using BlazorTable;
global using FluentValidation;

global using Microsoft.AspNetCore.Components.Authorization;
global using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;

global using System.Collections.Immutable;
global using System.Security.Claims;
global using System.Text.Json;

global using ZAOGST.WIS;
global using ZAOGST.WIS.CustomExceptions;
global using ZAOGST.WIS.Data.DataBaseContext;
global using ZAOGST.WIS.Data.Entities;
global using ZAOGST.WIS.Data.Interfaces;
global using ZAOGST.WIS.Data.Services;

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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseAuthentication();

app.UseStaticFiles();

app.UseRouting();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();