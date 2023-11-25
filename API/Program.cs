using API.Commons;
using API.Commons.Utils;
using API.Commons.Utils.CloudinaryService;
using API.Data;
using API.Data.Constants;
using API.Data.DTOs.Cloudinary;
using API.Data.DTOs.Mail;
using API.Data.Repositories;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add dependency injections
builder.Services.AddServices();
builder.Services.AddRepositories();

// Add CORs
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

// Config email service
builder.Services.Configure<MailSettingsModel>(builder.Configuration.GetSection("MailSettings"));
builder.Services.AddTransient<IMailService, MailService>();


// Config cloudinary service
builder.Services.Configure<CloudinarySettingsModel>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();

// Add auto mapper
builder.Services.AddAutoMapper(typeof(Maps).Assembly);

// Add Db Context
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add identity framework
builder.Services.AddIdentityService();

// Add authentication
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"] ?? string.Empty))
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwagger();

var app = builder.Build();

// Seed data
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    // Identity Authentication
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
    SeedData.Seed(roleManager).Wait();

    // AppCtl
    SeedData.Seed(serviceProvider).Wait();
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
