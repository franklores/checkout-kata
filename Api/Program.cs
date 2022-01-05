using Application.Interfaces;
using Application.Services;

using Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICheckout, Checkout>(_ => new Checkout(new List<Item>
        {
            new Item("A99", 0.50, new MultiBuyOffer("A99",3,1.30)),
            new Item("B15", 0.30, new MultiBuyOffer("B15", 2, 0.45)),
            new Item("C40", 0.60)
        }));

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