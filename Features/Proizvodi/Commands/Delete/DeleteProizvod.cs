using MediatR;

namespace CQRS.Features.Proizvodi.Commands.Delete;

public record DeleteProizvod(Guid Id) : IRequest;