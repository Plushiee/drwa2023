using System.Text;
using UAS_DRWA.Filters;
using UAS_DRWA.Models;
using UAS_DRWA.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<GuruDatabaseSettings>(
    builder.Configuration.GetSection("GuruDatabase"));
builder.Services.AddSingleton<GuruService>();

builder.Services.Configure<KelasDatabaseSettings>(
    builder.Configuration.GetSection("KelasDatabase"));
builder.Services.AddSingleton<KelasService>();

builder.Services.Configure<MapelDatabaseSettings>(
    builder.Configuration.GetSection("MapelDatabase"));
builder.Services.AddSingleton<MapelService>();

builder.Services.Configure<PresensiHarianGuruDatabaseSettings>(
    builder.Configuration.GetSection("PresensiHarianGuruDatabase"));
builder.Services.AddSingleton<PresensiHarianGuruService>();

builder.Services.Configure<PresensiMengajarDatabaseSettings>(
    builder.Configuration.GetSection("PresensiMengajarDatabase"));
builder.Services.AddSingleton<PresensiMengajarService>();

builder.Services.AddControllers()
 .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddTransient<ValidateModelAttribute>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Guru API",
        Description = "An ASP.NET Core Web API for managing Guru, by Nikolaus Pastika Bara Satyaradi - 72210456",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
});

//JWT -->
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

var app = builder.Build();
//<-- JWT

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//JWT -->
app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;
//<-- JWT

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
