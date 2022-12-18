using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Services.Fight;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OstreCWebContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("OstreCWEB")));

builder.Services.AddTransient<IFightService,FightService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services
    .AddAutoMapper(typeof(Program))
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation();

//builder.Host.UseSerilog((hostBuilderContext, loggerConfiguration) =>
//{
//    loggerConfiguration.WriteTo.Console();
//    loggerConfiguration.WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("OstreCWEB"), new MSSqlServerSinkOptions
//    {
//        AutoCreateSqlTable = true,
//        TableName = "OstreCWebLogs"
//    },
//    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning);
//});

var app = builder.Build();

var test = new StaticLists();
test.SeedData();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
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
//app.MapRazorPages();

app.MapControllerRoute(
    name: "storyBuilder",
    pattern: "{controller=Home}/{action=Index}/{id?}/{paragraphId?}");

app.Run();