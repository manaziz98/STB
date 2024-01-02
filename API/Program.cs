using DAL;
using Serilog;
using Service;
using System.Configuration;

var build = new ConfigurationBuilder();
build.AddJsonFile("appsettings.json");

var configuration = build.Build();

Log.Logger = new LoggerConfiguration()
              .ReadFrom.Configuration(configuration)
              .CreateLogger();

var builder = WebApplication.CreateBuilder(args);




builder.Services.Configure<DbContextSettings>(configuration);
builder.Services.AddSingleton(Log.Logger);
builder.Services.AddHttpContextAccessor();

builder.Services.AddService(configuration);
builder.Services.AddHttpClient();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        b => b.WithOrigins("*")
            .WithHeaders("*")
            .WithMethods("*")
            .WithExposedHeaders("*"));
});
 
builder.Services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


var app = builder.Build();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowSpecificOrigin");

app.Run();

