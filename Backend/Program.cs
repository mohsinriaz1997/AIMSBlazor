using Backend.Interface.MasterData;
using Backend.Interfaces.MasterData;
using Backend.Models;
using Backend.Repository.MasterData;
using Backend;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text;
using Backend.Interfaces.AdministrationData;
using Backend.Repository.AdministrationData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string? DBCon = builder.Configuration.GetSection("APIBaseUrl").ToString();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "JwtBearer";
    options.DefaultChallengeScheme = "JwtBearer";
}).AddJwtBearer("JwtBearer", JwtOptions =>
{
    JwtOptions.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MEPLWBCkiSecretKeyJWTkliyaBahutSecret")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromMinutes(30)
    };
});

builder.Services.AddDbContext<WBCContext>(options =>
options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddScoped<IUserProfile, UserProfileRepo>();
builder.Services.AddScoped<IActivityType, ActivityTypeRepo>();
builder.Services.AddScoped<IApprovalSetup, ApprovalSetup>();
builder.Services.AddScoped<IDepartmentMaster, DepartmentMasterRepo>();
builder.Services.AddScoped<IDesignationMaster, DesignationMasterRepo>();
builder.Services.AddScoped<IResourceMasterData, ResourceMasterData>();

Settings.TitleConfig = builder.Configuration.GetValue<string>("TitleConfig");
Settings.EmailConfig = builder.Configuration.GetValue<string>("EmailConfig");
Settings.PasswordConfig = builder.Configuration.GetValue<string>("PasswordConfig");
Settings.HostConfig = builder.Configuration.GetValue<string>("HostConfig");
Settings.PortConfig = builder.Configuration.GetValue<int>("PortConfig");
Settings.IsSSlConfig = builder.Configuration.GetValue<bool>("IsSSlConfig");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
