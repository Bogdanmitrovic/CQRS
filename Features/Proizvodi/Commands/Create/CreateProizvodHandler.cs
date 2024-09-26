using CQRS.Domain;
using CQRS.Persistence;
using MediatR;

namespace CQRS.Features.Proizvodi.Commands.Create;

public class CreateProizvodHandler(ProizvodDbContext context) : IRequestHandler<CreateProizvod, Guid>
{
    public async Task<Guid> Handle(CreateProizvod command, CancellationToken cancellationToken)
    {
        var product = new Proizvod(command.Naziv, command.Opis, command.Cena);
        await context.Proizvodi.AddAsync(product, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return product.Id;
    }
}