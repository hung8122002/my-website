using Microsoft.AspNetCore.Mvc;
using MISA.CukCuk.BL;
using MISA.CukCuk.BL.BaseBL;
using MISA.CukCuk.BL.DepartmentBL;
using MISA.CukCuk.BL.Position;
using MISA.CukCuk.DL;
using MISA.CukCuk.DL.BaseDL;
using MISA.CukCuk.DL.DepartmentDL;
using MISA.CukCuk.DL.EmployeeDL;
using MISA.CukCuk.DL.PositionDL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
        {
            policy.WithOrigins("http://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
        });
});

builder.Services.AddScoped<IEmployeeBL, EmployeeBL>();
builder.Services.AddScoped<IDepartmentBL, DepartmentBL>();
builder.Services.AddScoped<IPositionBL, PositionBL>();
builder.Services.AddScoped<IEmployeeDL, EmployeeDL>();
builder.Services.AddScoped<IDepartmentDL, DepartmentDL>();
builder.Services.AddScoped<IPositionDL, PositionDL>();
builder.Services.AddScoped(typeof(IBaseBL<>), typeof(BaseBL<>));
builder.Services.AddScoped(typeof(IBaseDL<>), typeof(BaseDL<>));

DataContext.DatabaseName = "MySQL";
DataContext.ConnectionString = builder.Configuration.GetConnectionString(DataContext.DatabaseName);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

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

app.UseCors();

app.Run();

