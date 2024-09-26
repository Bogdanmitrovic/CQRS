using MediatR;

namespace CQRS.Features.Proizvodi.Commands.Update;

public record UpdateProizvod(Guid Id, string Naziv, string Opis, decimal Cena) : IRequest;