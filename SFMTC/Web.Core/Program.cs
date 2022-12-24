using Data.Identity;
using Data.Services;
using Data.Services.Interfaces;
using Data.Services.Repositories;
using Datta.AppDataAccessLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<IdentityContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("IdentityContext");

    opt.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

builder.Services.AddDbContext<AppDataContext>(opt =>
{
    var connection = builder.Configuration.GetConnectionString("AppDataContext");

    opt.UseMySql(connection, ServerVersion.AutoDetect(connection));
});

builder.Services.AddTransient<ILayoutService, LayOutService>();

builder.Services.AddTransient<ICookingBookRepo, CookingBookRepository>();

builder.Services.AddControllers();

builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

app.Run();
