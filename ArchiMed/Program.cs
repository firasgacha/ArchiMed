using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArchiMed.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers; // place this line at the beginning of file.

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("dev",
        policy => { policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod(); });
});

// Connect to PostgreSQL Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ArchiMedDB>(options =>
    options.UseNpgsql(connectionString));

//... rest of the code omitted for brevity
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//... rest of the code omitted for brevity

var app = builder.Build();
//... rest of the code omitted for brevity

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("dev");
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();


app.UseAuthentication();
// app.UseAuthorization();
app.Run();


public class ArchiMedDB : DbContext
{
    public ArchiMedDB(DbContextOptions<ArchiMedDB> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasDiscriminator<string>("user_type")
            .HasValue<User>("admin")
            .HasValue<Doctor>("doctor")
            .HasValue<Agent>("agent")
            .HasValue<Patient>("patient");
    }
    // public DbSet<Appointment> Appointments { get; set; }
    // public DbSet<Scanner> Scanners{ get; set; }
    // public DbSet<MedicalFolder> MedicalFolders { get; set; }
    // public DbSet<Medications> Medications { get; set; }
    // public DbSet<MedicalOrder> MedicalOrders { get; set; }
    // public DbSet<Radio> Radios { get; set; }
    public DbSet<Department> Departments { get; set; }
    
    public DbSet<User?> Users { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    
    public DbSet<ArchiMed.Models.MedicalFolder>? MedicalFolder { get; set; }
    public DbSet<ArchiMed.Models.Appointment>? Appointment { get; set; }
    public DbSet<ArchiMed.Models.MedicalOrder>? MedicalOrder { get; set; }
    public DbSet<ArchiMed.Models.Medications>? Medications { get; set; }
    public DbSet<ArchiMed.Models.Scanner>? Scanner { get; set; }
    public DbSet<ArchiMed.Models.Radio>? Radio { get; set; }
    public DbSet<ArchiMed.Models.Contact>? Contact { get; set; }
    
    
}
