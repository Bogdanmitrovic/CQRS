using CQRS.Features.Proizvodi.DTOs;
using MediatR;

namespace CQRS.Features.Proizvodi.Queries.Get;

public record GetProizvod(Guid Id) : IRequest<ProizvodDTO?>;