using Microsoft.EntityFrameworkCore;
using RigelSolarAPI.Data;
using RigelSolarAPI.MappingConfig;
using RigelSolarAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers().AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RigelSolarContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<TecnicoRepository>();
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<FichaBanhoRepository>();
builder.Services.AddScoped<FichaPiscinaRepository>();

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
