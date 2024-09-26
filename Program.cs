using System.Reflection;
using CQRS.Features.Proizvodi.Commands.Create;
using CQRS.Features.Proizvodi.Commands.Delete;
using CQRS.Features.Proizvodi.Commands.Update;
using CQRS.Features.Proizvodi.Queries.Get;
using CQRS.Features.Proizvodi.Queries.List;
using CQRS.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProizvodDbContext>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/proizvodi/{id:guid}", async (Guid id, ISender mediatr) =>
{
    var product = await mediatr.Send(new GetProizvod(id));
    return product == null ? Results.NotFound() : Results.Ok(product);
});

app.MapGet("/proizvodi", async (ISender mediatr) =>
{
    var products = await mediatr.Send(new ListProizvod());
    return Results.Ok(products);
});

app.MapPut("/proizvodi", async (UpdateProizvod command, ISender mediatr) =>
{
    await mediatr.Send(command);
    return Results.NoContent();
});

app.MapPost("/proizvodi", async (CreateProizvod command, ISender mediatr) =>
{
    var productId = await mediatr.Send(command);
    return Guid.Empty == productId
        ? Results.BadRequest()
        : Results.Created($"/proizvodi/{productId}", new { id = productId });
});

app.MapDelete("/proizvodi/{id:guid}", async (Guid id, ISender mediatr) =>
{
    await mediatr.Send(new DeleteProizvod(id));
    return Results.NoContent();
});


app.UseHttpsRedirection();

app.Run();