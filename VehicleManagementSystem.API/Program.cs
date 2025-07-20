using VehicleManagementSystem.Application.Commands.AddTransport;
using VehicleManagementSystem.Application.Mappings;
using VehicleManagementSystem.Domain.Interfaces;
using VehicleManagementSystem.Infrastructure.DbContext;
using VehicleManagementSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<MongoDbContext>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITransportRepository, TransportRepository>();


builder.Services.AddAutoMapper(typeof(TransportMappingProfile).Assembly);
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(AddTransportCommand).Assembly));


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();