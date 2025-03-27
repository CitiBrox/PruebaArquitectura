using MediatR;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Interfaces;

namespace MauiApp1.Application.Queries;

/// <summary>
/// Consulta para obtener todos los productos.
/// </summary>
public record GetAllProductsQuery() : IRequest<List<Product>>;

/// <summary>
/// Handler para procesar la consulta GetAllProductsQuery.
/// </summary>
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
