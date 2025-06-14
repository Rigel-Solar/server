﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RigelSolarAPI.BLL;
using RigelSolarAPI.Data;
using RigelSolarAPI.MappingConfig;
using RigelSolarAPI.Repositories;
using RigelSolarAPI.Utils;
using System.Text;
using Resend;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
builder.Services.AddHttpClient<ResendClient>();
builder.Services.Configure<ResendClientOptions>(o =>
{
    o.ApiToken = Environment.GetEnvironmentVariable("RESEND_APITOKEN")!;
});
builder.Services.AddTransient<IResend, ResendClient>();

builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});
builder.Services.AddControllers().AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "RigelSolarAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    option.IncludeXmlComments(xmlPath);
});
builder.Services.AddDbContext<RigelSolarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<CoordenadorRepository>();
builder.Services.AddScoped<TecnicoRepository>();
builder.Services.AddScoped<GestorRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<FichaBanhoRepository>();
builder.Services.AddScoped<FichaPiscinaRepository>();
builder.Services.AddScoped<FichaFotovoltaicoRepository>();
builder.Services.AddScoped<FotoRepository>();
builder.Services.AddScoped<VistoriaRepository>();
builder.Services.AddScoped<JwtConfig>();
builder.Services.AddScoped<Encrypt>();
builder.Services.AddScoped<GenerateJwt>();
builder.Services.AddScoped<LoginBLL>();
builder.Services.AddScoped<CadastrarBLL>();
builder.Services.AddScoped<SendEmail>();
builder.Services.AddScoped<BlobStorage>();
builder.Services.AddScoped<EmailSMTP>();
builder.Services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration.GetSection("JwtSettings").GetValue<string>("Issuer"),
        ValidAudience = builder.Configuration.GetSection("JwtSettings").GetValue<string>("Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(builder.Configuration.GetSection("JwtSettings").GetValue<string>("SecretKey")!))
    });
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();