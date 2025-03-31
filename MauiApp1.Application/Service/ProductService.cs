using MauiApp1.Application.Commands;
using MauiApp1.Application.Queries;
using MauiApp1.Domain.Entities;
using MediatR;

/// <summary>
/// Capa de servicio que maneja la lógica de los productos
/// </summary>
public class ProductService
{
    private readonly IMediator _mediator;

    public ProductService(IMediator mediator)
    {
        _mediator = mediator;
    }


    /// <summary>
    /// Agrega un nuevo producto validando previamente que los datos sean correctos, mediante el envío del comando AddProductCommand a través de MediatR.
    /// </summary>
    /// <param name="product">El producto a agregar, debe tener un nombre válido y precio mayor que 0.</param>
    /// <returns>Una tarea que representa la operación asíncrona, cuyo resultado es el producto recién creado.</returns>
    /// <exception cref="ArgumentException">Se lanza si el nombre del producto está vacío o si el precio no es mayor que cero.</exception>
    public async Task<Product> AddProductAsync(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name) || product.Price <= 0)
        {
            throw new ArgumentException("El nombre del producto no puede estar vacío y el precio debe ser mayor que 0.");
        }

        var newProduct = await _mediator.Send(new AddProductCommand(product.Name, product.Price));
        return newProduct;
    }

    /// <summary>
    /// Recupera todos los productos disponibles mediante el envío de una consulta GetAllProductsQuery a través de MediatR.
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona, cuyo resultado es una colección de productos.</returns>
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return products;
    }
}
