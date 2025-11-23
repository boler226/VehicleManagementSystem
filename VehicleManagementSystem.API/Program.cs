using MongoDB.Bson;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using VehicleManagementSystem.API.Extensions;
using VehicleManagementSystem.API.Middlewares;
using VehicleManagementSystem.Application.Commands.Transport.AddTransport;
using VehicleManagementSystem.Application.Mappings;
using VehicleManagementSystem.Domain.Interfaces.Identity;
using VehicleManagementSystem.Infrastructure.DbContext;
using VehicleManagementSystem.Infrastructure.Extensions;
using VehicleManagementSystem.Infrastructure.Identity;
using FluentValidation.AspNetCore;
using VehicleManagementSystem.Application.Validators.Auth;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

builder.Services.AddSingleton<MongoDbContext>();
builder.Services.AddSingleton<IMongoClient>(sp =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase("VehicleManagementSystemDb");
});

builder.Services.AddControllers();
builder.Services.AddCorsPolicy();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddRepositories();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddTransient<ErrorHandlingMiddleware>();
builder.Services.AddTransient<RoleHandlingMiddleware>();

builder.Services.AddAutoMapper(typeof(TransportMappingProfile).Assembly);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AddTransportCommand).Assembly));
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();

builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<RegisterUserCommandValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<RoleHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseCorsPolicy();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();