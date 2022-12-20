using DAL;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<AppDbContext>(Options =>
//{
//    Options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"),
//        sqlServerOptionsAction: sqloptions =>
//        {
//            sqloptions.EnableRetryOnFailure(
//                maxRetryCount: 10,
//                maxRetryDelay: TimeSpan.FromSeconds(5),
//                errorNumbersToAdd: null);
//        }
// )}
//            );

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));

});





// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
