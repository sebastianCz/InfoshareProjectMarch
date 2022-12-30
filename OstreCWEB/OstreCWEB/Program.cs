using Microsoft.EntityFrameworkCore;
using OstreCWEB.Data.DataBase;
using OstreCWEB.Data.Repository.Characters;
using OstreCWEB.Data.Repository.Characters.Interfaces;
using OstreCWEB.Data.Repository.Fight;
using OstreCWEB.Services.Factories;
using OstreCWEB.Services.Fight;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Allows retrying CRUD operations in case of transient failures.
builder.Services.AddDbContext<OstreCWebContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("OstreCWEB"), builder =>builder.EnableRetryOnFailure(2, TimeSpan.FromSeconds(2), null)));
 

builder.Services.AddTransient<IFightService,FightService>();
builder.Services.AddTransient<IFightRepository, FightRepository>();
builder.Services.AddTransient<IFightFactory, FightFactory>();
builder.Services.AddTransient<ISeeder, DBSeeder>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ICharacterActionsRepository, CharacterActionRepository>();

//builder.Services.AddTransient<IPlayableCharacterRepository,  >();
//builder.Services.AddTransient<IEnemyRepository,  >();

//builder.Services.AddTransient<ICharacterClassRepository,  >();
//builder.Services.AddTransient<ICharacterRaceRepository,  >();
//builder.Services.AddTransient<IItemRepository,  >();



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
   
builder.Services.AddSwaggerGen();
var app = builder.Build();

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
//app.MapRazorPages();

app.MapControllerRoute(
    name: "storyBuilder",
    pattern: "{controller=Home}/{action=Index}/{id?}/{paragraphId?}");
 
app.Run();