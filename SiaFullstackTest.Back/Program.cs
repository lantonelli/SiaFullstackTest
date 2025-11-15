using Microsoft.EntityFrameworkCore;
using SiaFullstackTest.Back.Data;
using SiaFullstackTest.Back.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost62165",
        policy => policy.WithOrigins("http://127.0.0.1:62165")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowLocalhost62165");

app.UseAuthorization();

app.MapControllers();

app.Run();
