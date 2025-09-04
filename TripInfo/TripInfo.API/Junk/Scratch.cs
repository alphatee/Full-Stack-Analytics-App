using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TripInfo.API.DbContexts;
using TripInfo.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson() // Add JSON support for the API, adding I/O Formatters using Json.NET
  .AddXmlDataContractSerializerFormatters(); // Add XML support for the API, adding I/O Formatters
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // TripInfo.API and adds extension .xml
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile); // go to properties and above events to see approved xml documentation checked. 

    setupAction.IncludeXmlComments(xmlCommentsFullPath);
});
builder.Services.AddSingleton<FileExtensionContentTypeProvider>(); //Registered service as a singleton

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else 
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddDbContext<TripInfoContext>(options =>
        options.UseSqlServer(builder.Configuration
        .GetConnectionString("TripInfoConnectionString")));

builder.Services.AddScoped<ITripInfoRepository, TripInfoRepository>(); // pass the contract and the implementation

builder.Services.AddScoped<ITripInfoService, TripInfoService>(); // pass the contract and the implementation (i.e.,  correctly register)

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // the TripInfo.API assembly(current), will be scanned for profiles

builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true; // we do not need to pass through an explicit request version to get back data.
    setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0); // if no version is specified, the default version will be used.
    setupAction.ReportApiVersions = true; // the response will include the supported versions
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        policy.WithOrigins("http://localhost:4200") // Replace with the actual origin of your Angular app
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripInfo v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

/*
// Must integrate this function somehow to proceed.
// Go to a new branch to refactor Program.cs and Startup.cs to scale this application.
public JwtSettings GetJwtSettings()
{
    JwtSettings settings = new JwtSettings();

    settings.Key = Configuration["JwtToken:key"];
    settings.Audience = Configuration["JwtToken:audience"];
    settings.Issuer = Configuration["JwtToken:issuer"];
    settings.MinutesToExpiration = 
        Convert.ToInt32(
            Configuration["JwtToken:minutestoexpiration"]);

    return settings;
}


public void ConfigureJwt(IServiceCollection services)
{
    // Get JWT Token Settings from appsettings.json file 
    JwtSettings settings = GetJwtSettings(); 
    services.AddSingleton<JwtSettings>(settings);
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "JwtBearer";
        options.DefaultChallengeScheme = "JwtBearer";

    })
        .AddJwtBearer("JwtBearer", jwtBearerOptions =>
        {
            jwtBearerOptions.TokenValidationParameters =
            new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(settings.Key)),
                ValidateIssuer = true,
                ValidIssuer = settings.Issuer,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(
                        settings.MinutesToExpiration)
            };
        });
}
*/

/*                  <Objective>
 * Scratch.cs 
 * A) delete all the unnessary stuff 
 * B) Read documentation of .NET 7 
 * on how to bring this code up the standard 
 * and create a class to use methods 
 * 
 * C) Try to bring the changes in Scratch.cs to OldProgram.cs
 * D) Between Scratch.cs and OldProgram.cs figure out which to 
 * continue developing with.
 * 
 */

