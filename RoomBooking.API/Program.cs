using Microsoft.EntityFrameworkCore;
using RoomBooking.CORE.Interfaces.Repositories;
using RoomBooking.CORE.Interfaces.Services;
using RoomBooking.Infrastructure.Data;
using RoomBooking.Infrastructure.Repositories;
using RoomBooking.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRoomRepository,RoomRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IBookingRepository,BookingRepository>();

builder.Services.AddScoped<IBookingService,BookingService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
