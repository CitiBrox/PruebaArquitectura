using MediatR;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Interfaces;

namespace MauiApp1.Application.Commands;

/// <summary>
/// Comando para agregar un nuevo producto.
/// </summary>
public record AddProductCommand(Product product) : IRequest<Product>;

/// <summary>
/// Handler para procesar AddProductCommand.
/// </summary>
public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public AddProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    ///  Guardar el nuevo producto usando el repositorio y retornar el producto agregado
    /// </summary>
    /// <param name="request">Record de tipo AddProductCommand</param>
    /// <param name="_">strunct implementado de IRequestHandler</param>
    /// <returns></returns>
    public async Task<Product> Handle(AddProductCommand request, CancellationToken _)
    {
         var productHandle = request.product;
        return await _repository.AddAsync(productHandle);
    }
}
