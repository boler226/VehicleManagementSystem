using VehicleManagementSystem.API.Middlewares;
using VehicleManagementSystem.Application.Commands.Transport.AddTransport;
using VehicleManagementSystem.Application.Mappings;
using VehicleManagementSystem.Infrastructure.DbContext;
using VehicleManagementSystem.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();

builder.Services.AddAutoMapper(typeof(TransportMappingProfile).Assembly);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AddTransportCommand).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();