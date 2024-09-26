using MediatR;

namespace CQRS.Features.Proizvodi.Commands.Create;

public record CreateProizvod(string Naziv, string Opis, decimal Cena) : IRequest<Guid>;