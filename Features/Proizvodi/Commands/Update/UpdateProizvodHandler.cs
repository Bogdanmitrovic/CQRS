using CQRS.Features.Proizvodi.Commands.Delete;
using CQRS.Persistence;
using MediatR;

namespace CQRS.Features.Proizvodi.Commands.Update;

public class UpdateProizvodHandler(ProizvodDbContext context) : IRequestHandler<UpdateProizvod>
{
    public async Task Handle(UpdateProizvod request, CancellationToken cancellationToken)
    {
        var product =
            await context.Proizvodi.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        if (product == null) return;
        product.Naziv = request.Naziv;
        product.Opis = request.Opis;
        product.Cena = request.Cena;
        await context.SaveChangesAsync(cancellationToken);
    }
}