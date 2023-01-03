using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Data.Repository.Identity;
using OstreCWEB.Data.Repository.WebObjects;
using OstreCWEB.Services.Factories;
using OstreCWEB.Services.Fight;
using OstreCWEB.Services.Identity;
using OstreCWEB.Services.Test;
using OstreCWEB.Data.InitialData;
using OstreCWEB.Data.ServiceRegistration;
using OstreCWEB.Services.ServiceRegistration;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OstreCWebContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("OstreCWEB")));

// for Identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<OstreCWebContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/LoginController/Login");

builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

builder.Services.AddTransient<IFightService,FightService>();
builder.Services.AddTransient<IFightRepository, FightRepository>();
builder.Services.AddTransient<IFightFactory, FightFactory>();
builder.Services.AddTransient<ISeeder, DBSeeder>(); 
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services
    .AddAutoMapper(typeof(Program))
    .AddControllersWithViews()
.AddRazorRuntimeCompilation();

builder.Services
    .AddRepositories();

builder.Services
    .AddServices();

builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
    loggerConfiguration.WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("OstreCWEB"), new MSSqlServerSinkOptions
    {
        AutoCreateSqlTable = true,
        TableName = "OstreCWebLogs"
    },
    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning);
});

builder.Services.AddSwaggerGen();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

var test = new StaticLists();
test.SeedData(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "storyBuilder",
    pattern: "{controller=Home}/{action=Index}/{id?}/{paragraphId?}");
 
app.Run();