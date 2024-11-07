using AspNetCoreRateLimit;
using BusinessLayer.Interface;
using BusinessLayer.MediatR;
using BusinessLayer.Provider;
using DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net.NetworkInformation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddInMemoryRateLimiting();
var connectionstring = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
builder.Services.AddScoped<ICandidateInformation,CandidateProvider>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIpRateLimiting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
