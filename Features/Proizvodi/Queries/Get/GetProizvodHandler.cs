using CQRS.Features.Proizvodi.DTOs;
using CQRS.Persistence;
using MediatR;

namespace CQRS.Features.Proizvodi.Queries.Get;

public class GetProizvodHandler(ProizvodDbContext context)
    : IRequestHandler<GetProizvod, ProizvodDTO?>
{
    public async Task<ProizvodDTO?> Handle(GetProizvod request, CancellationToken cancellationToken)
    {
        var product =
            await context.Proizvodi.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
        return product == null ? null : new ProizvodDTO(product.Id, product.Naziv, product.Opis, product.Cena);
    }
}