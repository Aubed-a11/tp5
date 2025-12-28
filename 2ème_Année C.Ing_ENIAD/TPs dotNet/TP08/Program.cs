using TP08.Repositories.Interfaces;
using TP08.Repositories;
using TP08.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProductRepository>(provider =>
{
    var cs = provider.GetRequiredService<IConfiguration>()
        .GetConnectionString("db");
    return new ProductRepository(cs);
});

builder.Services.AddScoped<ProductService>();


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
