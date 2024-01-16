global using BlazorTable;
global using FluentValidation;
global using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
global using Microsoft.EntityFrameworkCore;
global using ZAOGST.WIS.Data.DataBaseContext;
global using ZAOGST.WIS.Data.Entities;
global using ZAOGST.WIS.Data.Interfaces;
global using ZAOGST.WIS.Data.Services;

//TODO: Сделать страницу отгрузки

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IControlBlockService, ControlBlockService>();
builder.Services.AddScoped<IBallonService, BallonService>();
builder.Services.AddScoped<IShippedControlBlockService, ShippedControlBlockService>();
builder.Services.AddScoped<IShippedBallonService, ShippedBallonService>();
builder.Services.AddSqlite<DataContext>(@"Data Source=Data\DataBase\ZAOGST.WIS.DataBase.db");
builder.Services.AddBlazorTable();
//builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
