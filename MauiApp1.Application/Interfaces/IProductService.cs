using MauiApp1.Domain.Entities;

namespace MauiApp1.Application.Interfaces;

public interface IProductService
{
    /// <summary>
    /// Agrega un nuevo producto validando previamente que los datos sean correctos, mediante el envío del comando AddProductCommand a través de MediatR.
    /// </summary>
    /// <param name="product">El producto a agregar, debe tener un nombre válido y precio mayor que 0.</param>
    /// <returns>Una tarea que representa la operación asíncrona, cuyo resultado es el producto recién creado.</returns>
    /// <exception cref="ArgumentException">Se lanza si el nombre del producto está vacío o si el precio no es mayor que cero.</exception>
    public Task<Product> AddProductAsync(Product product);

    /// <summary>
    /// Recupera todos los productos disponibles mediante el envío de una consulta GetAllProductsQuery a través de MediatR.
    /// </summary>
    /// <returns>Una tarea que representa la operación asíncrona, cuyo resultado es una colección de productos.</returns>
    public Task<List<Product>> GetAllProductsAsync();
    
}