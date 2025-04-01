using MediatR;
using MauiApp1.Application.Interfaces;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Queries;

namespace MauiApp1.Application.Handlers;

/// <summary>
/// Handler que maneja la consulta GetAllProductsQuery.
/// </summary>
public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Maneja la consulta GetAllProductsQuery para obtener todos los productos almacenados.
    /// </summary>
    /// <param name="request">Consulta de tipo GetAllProductsQuery</param>
    /// <param name="cancellationToken">Token para observar mientras se espera la tarea, que permite cancelar la operación.</param>
    /// <returns>Una tarea que representa la operación asíncrona. El resultado contiene una lista con todos los productos.</returns>
    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        // Obtener todos los productos desde el repositorio
        return await _repository.GetAllAsync();
    }
}
