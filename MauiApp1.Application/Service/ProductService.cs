// Servicio que maneja la lógica de los productos
using MauiApp1.Application.Commands;
using MauiApp1.Application.Queries;
using MauiApp1.Domain.Entities;
using MediatR;

public class ProductService
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Método para agregar un producto
    public async Task<Product> AddProductAsync(string productName, decimal productPrice)
    {
        if (string.IsNullOrWhiteSpace(productName) || productPrice <= 0)
        {
            throw new ArgumentException("El nombre del producto no puede estar vacío y el precio debe ser mayor que 0.");
        }

        var newProduct = await _mediator.Send(new AddProductCommand(productName, productPrice));
        return newProduct;
    }

    // Método para obtener todos los productos
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return products;
    }
}
