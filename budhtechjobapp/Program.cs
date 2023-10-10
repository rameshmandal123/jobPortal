using budhtechjobapp.Data;
using budhtechjobapp.DbConfigures;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("postgressDBConection")));

// Register IAuthDL with scoped lifetime
builder.Services.AddScoped<IAuthDL, AuthDL>();
builder.Services.AddScoped<MyDbContext>();
builder.Services.AddScoped<IJobListingDL,JobListingDL>();
builder.Services.AddScoped<IJobApplicationDL,JobApplicationDL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();

app.MapControllers();

app.Run();
