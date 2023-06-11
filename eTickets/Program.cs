using eTickets.Data;
using eTickets.Data.Base;
using eTickets.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnectionString")
    ));
// to inject a service in a controller, we need to first register that service in program.cs file
// dotnet services has 3 major dependency injection life times:
// Singleton lifetime: createad once throught out applciation. It is same for all program
// Scoped: Created once per request within the scope. Same request within a request but different for different scopes
// Transient: Createad each time when they are requested.
// two parameters: 1. interface in which we are going to inject our controller
// second paramaeter: 2. implementation of the service of the interface used in paramter 1
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<IProducersService, ProducersService>();
builder.Services.AddScoped<ICinemasService, CinemasService>();

builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

AddDbInitializer.Seed(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
