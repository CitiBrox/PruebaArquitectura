using MediatR;
using MauiApp1.Application.Interfaces;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Commands;

namespace MauiApp1.Application.Handlers;

/// <summary>
/// Handler que maneja el comando AddProductCommand.
/// </summary>
public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly IProductRepository _repository;

    public AddProductCommandHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    ///  Crear un nuevo producto con los datos enviados y guarda el producto en el repositorio
    /// </summary>
    /// <param name="request">Objeto de tipo AddProductCommand</param>
    /// <param name="cancellationToken">Estructura de tipo CancellationToken</param>
    /// <returns></returns>
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        return await _repository.AddAsync(newProduct);
    }
}
