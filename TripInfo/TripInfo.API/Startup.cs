namespace TripInfo.API;

using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TripInfo.API.DbContexts;
using TripInfo.API.Entities;
using TripInfo.API.Services.MailServices;
using TripInfo.API.Services.Repositories;
using TripInfo.API.Services.TripInfoServices;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Tell this project to allow CORS
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAngularApp", builder =>
            {
                builder.WithOrigins("https://angular-app-b8ebe3f0czefapax.westus2-01.azurewebsites.net",
                   "http://localhost:4200")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        ConfigureJwt(services); // set up

        services.AddAuthorization(cfg =>
        {
            // NOTE: The claim key and value are case-sensitive
            cfg.AddPolicy("CanAccessTravelDetails", p =>
                p.RequireClaim("CanAccessTravelDetails", "true"));
        });

        // Add services to the container.
        services.AddControllers(options =>
        {
            options.ReturnHttpNotAcceptable = true;
        }).AddNewtonsoftJson() // Add JSON support for the API, adding I/O Formatters using Json.NET
          .AddXmlDataContractSerializerFormatters(); // Add XML support for the API, adding I/O Formatters
                                                     // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(setupAction =>
        {
            var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; // TripInfo.API and adds extension .xml
            var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile); // go to properties and above events to see approved xml documentation checked. 

            setupAction.IncludeXmlComments(xmlCommentsFullPath);
        });
        services.AddSingleton<FileExtensionContentTypeProvider>(); //Registered service as a singleton

        // Mail Services
        services.AddScoped<ITripInfoService, TripInfoService>();

        #if DEBUG
        services.AddTransient<IMailService, LocalMailService>();
        #else
        services.AddTransient<IMailService, CloudMailService>();
        #endif

                            // Lesson about AddScoped
        /**
         * In this example, AddScoped is used to register the service, which means a new instance of EmailService will be created once per request.

        After you’ve added this line to your ConfigureServices method, the application should be able to resolve IEmailService and create an instance of TripsController
        */
        services.AddScoped<IEmailService, EmailService>();

        services.AddDbContext<TripInfoContext>(options =>
                options.UseSqlServer(Configuration
                .GetConnectionString("TripInfoConnectionString")));

        services.AddScoped<ITripInfoRepository, TripInfoRepository>(); // pass the contract and the implementation

        services.AddScoped<ITripInfoService, TripInfoService>(); // pass the contract and the implementation (i.e.,  correctly register)

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // the TripInfo.API assembly(current), will be scanned for profiles

        services.AddApiVersioning(setupAction =>
        {
            setupAction.AssumeDefaultVersionWhenUnspecified = true; // we do not need to pass through an explicit request version to get back data.
            setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0); // if no version is specified, the default version will be used.
            setupAction.ReportApiVersions = true; // the response will include the supported versions
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        //if (env.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TripInfoAPI v1"));
        //}

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors("AllowAngularApp");

        app.UseAuthentication(); // This is the commit to add this Use feature, after creating ConfigureJwt(services)

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

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
                        Encoding.UTF8.GetBytes(settings.Key)), // have a signing key, the big long key in appsettings.json expressed as a long series of bytes
                    ValidateIssuer = true,
                    ValidIssuer = settings.Issuer, // this web api url

                    ValidateAudience = true,
                    ValidAudience = settings.Audience, 

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(
                            settings.MinutesToExpiration)
                };
            });
    }
}