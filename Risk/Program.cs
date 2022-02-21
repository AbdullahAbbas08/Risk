using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Risk_Business_Layer.IRepositories.ICrud;
using Risk_Business_Layer.IUnitOfWork.ICrud;
using Risk_Business_Layer.IUnitOfWork.IUnitOfWork_Crud;
using Risk_Business_Layer.Repositories.Crud;
using Risk_Business_Layer.Seeds;
using Risk_Business_Layer.UnitOfWork.UnitOfWork_Crud;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

#region AddTransient
builder.Services.AddTransient(typeof(ICrud<>), typeof(Crud<>));
builder.Services.AddTransient<IUnitOfWork_Crud, UnitOfWork_Crud>();
builder.Services.AddTransient<ICallReasonBusiness<CallReason>, CallReasonBusiness>();
builder.Services.AddTransient<ICityBusiness<City>, CityBusiness>();
builder.Services.AddTransient<IGovernorateBusiness<Governorate>, GovernorateBusiness>();
builder.Services.AddTransient<ISourceMarketingBusiness<SourceMarketing>, SourceMarketingBusiness>();
builder.Services.AddTransient<IClientTypeBusiness<ClientType>, ClientTypeBusiness>();
#endregion

#region Map Classes Into Appsettings
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
#endregion

#region Apply Identity 
builder.Services.AddIdentity<Employee,IdentityRole>().AddEntityFrameworkStores<RiskDbContext>();
#endregion

#region Add Context
builder.Services.AddDbContext<RiskDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

#region Mapped Classes 
builder.Services.AddScoped<IAuthService, AuthService>();
#endregion

#region Swagger Configurations
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
            //Swagger Header
            options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Risk API",
        Description = "Description Not Added Yet "
    });

            //Swagger Definition For All 
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\nExample: \"Bearer 12345abcdef\""
    });

            //Swagger Definition For One Controller
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                        },
                        Name = "Bearer",
                         In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
    });
});
#endregion


var app = builder.Build();

#region Seed Users And Roles
using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;
var loggerFactory = services.GetRequiredService<ILoggerProvider>();
var logger = loggerFactory.CreateLogger("app");

try
{
    var userManager = services.GetRequiredService<UserManager<Employee>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await DefaultRoles.SeedRole(roleManager);
    await DefaultUsers.SeedAgentUser(userManager);
    await DefaultUsers.SeedAdminUser(userManager, roleManager);

    logger.LogInformation("Data seeded");
    logger.LogInformation("Application Started");
}
catch (System.Exception ex)
{
    logger.LogWarning(ex, "An error occurred while seeding data");
}

#endregion

#region Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#endregion

app.UseAuthorization();

app.MapControllers();


app.Run();
