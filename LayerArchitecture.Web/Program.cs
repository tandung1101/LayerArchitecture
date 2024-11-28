using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using LayerArchitecture.Repository;
using LayerArchitecture.Service.Mapping;
using LayerArchitecture.Service.Validations;
using LayerArchitecture.Web.Modules;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>()); ;
builder.Services.AddAutoMapper(typeof(MapProfile));
var connectionString = builder.Configuration.GetConnectionString("SqlConnection") ?? throw new Exception("Connectionstring cannot be null");
builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(connectionString, options =>
    {
        options.MigrationsAssembly("LayerArchitecture.Repository");
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    containerBuilder.RegisterModule(new RepoServiceModule()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
