using CQRS.Features.Proizvodi.DTOs;
using MediatR;

namespace CQRS.Features.Proizvodi.Queries.List;

public record ListProizvod : IRequest<List<ProizvodDTO>>;