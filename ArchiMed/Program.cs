using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ArchiMed.Models;
using ArchiMed.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models; // place this line at the beginning of file.

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
        ValidateIssuerSigningKey = true,
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

app.UseAuthorization();

app.MapControllers();


// app.MapPost("/patient/", async(Patient n, PatientDb db)=> {
//     db.Patients.Add(n);
//     await db.SaveChangesAsync();
//
//     return Results.Created($"/patient/{n.PatientId}", n);
// });
//
// app.MapGet("/patient/{id:int}", async(int id, PatientDb db)=> 
// {
//     return await db.Patients.FindAsync(id)
//         is Patient n
//         ? Results.Ok(n)
//         : Results.NotFound();
// });
//
// app.MapGet("/patient", async (PatientDb db) => await db.Patients.ToListAsync());
//
// app.MapPut("/notes/{id:int}", async(int id, Patient n, PatientDb db)=>
// {
//     if (n.PatientId != id)
//     {
//         return Results.BadRequest();
//     }
//
//     var patient = await db.Patients.FindAsync(id);
//     
//     if (patient is null) return Results.NotFound();
//
//     //found, so update with incoming note n.
//     patient.nom = n.nom;
//     patient.prenom = n.prenom;
//     
//     await db.SaveChangesAsync();
//     return Results.Ok(patient);
// });
//
// app.MapDelete("/notes/{id:int}", async(int id, PatientDb db)=>{
//
//     var patient = await db.Patients.FindAsync(id);
//     if (patient is not null){
//         db.Patients.Remove(patient);
//         await db.SaveChangesAsync();
//     }
//     return Results.NoContent();
// });



app.MapPost("/login",
        (UserLogin user, IUserService service) => Login(user, service))
    .Accepts<UserLogin>("application/json")
    .Produces<string>();

IResult Login(UserLogin user, IUserService service)
{
    if (!string.IsNullOrEmpty(user.email) &&
        !string.IsNullOrEmpty(user.password))
    {
        var loggedInUser = service.Get(user);
        if (loggedInUser is null) return Results.NotFound("User not found");

        var claims = new[]
        {
            new Claim(ClaimTypes.Email, loggedInUser.email),
            new Claim(ClaimTypes.Surname, loggedInUser.lastName),
            new Claim(ClaimTypes.Role, loggedInUser.role)
        };

        var token = new JwtSecurityToken
        (
            claims: claims,
            expires: DateTime.UtcNow.AddDays(60),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                SecurityAlgorithms.HmacSha256)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Results.Ok(tokenString);
    }
    return Results.BadRequest("Invalid user credentials");
}

app.Run();



public class ArchiMedDB : DbContext
{
    public ArchiMedDB(DbContextOptions<ArchiMedDB> options) : base(options)
    {
    }

    // public DbSet<Patient> Patients => Set<Patient>();
    // public DbSet<Appointment> Appointments { get; set; }
    // public DbSet<Scanner> Scanners{ get; set; }
    // public DbSet<MedicalFolder> MedicalFolders { get; set; }
    // public DbSet<Medications> Medications { get; set; }
    // public DbSet<MedicalOrder> MedicalOrders { get; set; }
    // public DbSet<Radio> Radios { get; set; }
    // public DbSet<Agent> Agents { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<ArchiMed.Models.Patient>? Patient { get; set; }
    public DbSet<ArchiMed.Models.MedicalFolder>? MedicalFolder { get; set; }
    public DbSet<ArchiMed.Models.Appointment>? Appointment { get; set; }
    public DbSet<ArchiMed.Models.Agent>? Agent { get; set; }
    public DbSet<ArchiMed.Models.MedicalOrder>? MedicalOrder { get; set; }
    public DbSet<ArchiMed.Models.Medications>? Medications { get; set; }
    public DbSet<ArchiMed.Models.Scanner>? Scanner { get; set; }
    public DbSet<ArchiMed.Models.Radio>? Radio { get; set; }
    public DbSet<ArchiMed.Models.Contact>? Contact { get; set; }
}