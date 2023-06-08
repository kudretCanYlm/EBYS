using EBYS.BlazorServer.Data;
using EBYS.BusinessLayer;
using EBYS.DataAccesLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prometheus;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDataAccesLayer(x => x.UseSqlServer(builder.Configuration.GetConnectionString("EBYS")));
builder.Services.AddBusinessLayer();
builder.Services.AddHttpContextAccessor();

var key = Encoding.ASCII.GetBytes(builder.Configuration["Key"]);

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();

builder.Services.AddAuthentication(x =>
{
	x.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
	x.RequireHttpsMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(key),
		ValidateIssuer = false,
		ValidateAudience = false
	};
}).AddCookie(options =>
{
	options.LoginPath = "/giris";
	options.LogoutPath = "/cikis";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.ApplyMigration();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseHttpMetrics();
app.MapMetrics();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
