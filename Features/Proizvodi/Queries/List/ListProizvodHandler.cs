using CQRS.Domain;
using CQRS.Features.Proizvodi.DTOs;
using CQRS.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Features.Proizvodi.Queries.List;

public class ListProizvodHandler(ProizvodDbContext context) : IRequestHandler<ListProizvod, List<ProizvodDTO>>
{
    public async Task<List<ProizvodDTO>> Handle(ListProizvod request, CancellationToken cancellationToken)
    {
        if (!Proizvod.IsCached)
        {
            var millisecondsRandom = new Random().Next(0, 200);
            await Task.Delay(millisecondsRandom, cancellationToken);
            Proizvod.IsCached = true;
        }

        return await context.Proizvodi
            .Select(p => new ProizvodDTO(p.Id, p.Naziv, p.Opis, p.Cena))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}