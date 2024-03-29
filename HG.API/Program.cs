using HG.Infrastructure;
using HG.Infrastructure.Repository;
using HG.Infrastructure.Repository.EF_Core;
using HG.Infrastructure.Services.PostService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<HowlingGigglesContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("HGDBConnectionString"), new MySqlServerVersion(new Version(8, 0, 29)))
);

builder.Services.AddCors();

builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Production A");
    options.RoutePrefix = String.Empty;
});

app.UseHttpsRedirection();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
