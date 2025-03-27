using MediatR;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Interfaces;

namespace MauiApp1.Application.Commands;

/// <summary>
/// Comando para agregar un nuevo producto.
/// </summary>
public record AddProductCommand(string Name, decimal Price) : IRequest<Product>;

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

    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var newProduct = new Product { Name = request.Name, Price = request.Price };
        return await _repository.AddAsync(newProduct);
    }
}
