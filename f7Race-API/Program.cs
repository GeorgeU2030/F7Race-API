using System.Text.Json.Serialization;
using dotenv.net;
using f7Race_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using f7Race_API.Custom;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

DotEnv.Load();

var url = Environment.GetEnvironmentVariable("FRONTEND_URL");
var jwtkey = Environment.GetEnvironmentVariable("JWT_SECRET");

var jwt_secret = jwtkey ?? "my_secret_key";
var frontend_url = url ?? "http://localhost:4200";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins(frontend_url)
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var postgresSQL = Environment.GetEnvironmentVariable("POSTGRES_SQL");
var connectionString = postgresSQL;

builder.Services.AddDbContext<F7Db>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddSingleton<Utilities>(ServiceProvider => {
    var jwtSecret = Environment.GetEnvironmentVariable("JWT_SECRET") ?? string.Empty;
    return new Utilities(jwtSecret);
});

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config => {
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters{
        ValidateIssuerSigningKey = true,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt_secret))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
