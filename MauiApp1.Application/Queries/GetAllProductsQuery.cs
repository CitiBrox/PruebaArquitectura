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

    /// <summary>
    /// Maneja la consulta GetAllProductsQuery para recuperar todos los productos almacenados.
    /// </summary>
    /// <param name="request">La consulta solicitada</param>
    /// <param name="cancellationToken">Token para observar mientras se espera la tarea, permitiendo cancelar la operación si es necesario.</param>
    /// <returns>Una tarea que representa la operación asíncrona, cuyo resultado es una lista con todos los productos.</returns>
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
