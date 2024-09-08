using Microsoft.EntityFrameworkCore;
using Neuca.TestFlight.Api.Extensions.CustomDocumentation;
using Neuca.TestFlight.Api.Extensions.Routes;
using Neuca.TestFlight.Api.Extensions.Seed;
using Neuca.TestFlight.Api.Middlewares;
using Neuca.TestFlight.Application.OtherArea;
using Neuca.TestFlight.Application.Services;
using Neuca.TestFlight.Infrastructure;
using Neuca.TestFlight.Infrastructure.IdentityEmulator;
using Neuca.TestFlight.Infrastructure.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => { options.EnableAnnotations(); });

builder.Services.AddDbContext<InMemoryDbContext>(options =>
    options.UseInMemoryDatabase("ScopedDatabase"));

builder.Services.AddScoped<IdentityService>();
builder.Services.AddScoped<PriceServiceLocator>();

builder.Services.AddAutoMapper(typeof(OtherMapperProfile).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(InitialCommand).Assembly));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.Seed();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.CreateDataDocumentation();
    app.CreateModelDocumentation();
}

app.UseHttpsRedirection();
app.DefineRoutes();
app.UseMiddleware(typeof(ErrorHandlingMiddleware));

ServiceLocator.ServiceProvider = app.Services;
IdentitySessionState.User = "Adam";

app.UseStaticFiles();
app.Run();