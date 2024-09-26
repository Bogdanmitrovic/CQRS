using CQRS.Persistence;
using MediatR;

namespace CQRS.Features.Proizvodi.Commands.Delete;

public class DeleteProizvodHandler(ProizvodDbContext context) : IRequestHandler<DeleteProizvod>
{
    public async Task Handle(DeleteProizvod request, CancellationToken cancellationToken)
    {
        var product =
            await context.Proizvodi.FindAsync([request.Id], cancellationToken: cancellationToken);
        if (product == null) return;
        context.Proizvodi.Remove(product);
        await context.SaveChangesAsync(cancellationToken);
    }
}