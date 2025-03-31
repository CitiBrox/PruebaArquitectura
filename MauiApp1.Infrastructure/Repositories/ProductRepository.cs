using MauiApp1.Application.Interfaces;
using MauiApp1.Domain.Entities;
using System.Collections.Concurrent;

namespace MauiApp1.Infrastructure.Repositories;

/// <summary>
/// Implementación en memoria de IProductRepository.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly ConcurrentBag<Product> _storage = new();

    public Task<List<Product>> GetAllAsync() => Task.FromResult(_storage.ToList());

    /// <summary>
    /// Agrega un producto.
    /// </summary>
    /// <param name="product">El producto que será agregado al almacenamiento.</param>
    /// <returns>Una tarea que representa la operación asíncrona, cuyo resultado es el producto agregado.</returns>
    public Task<Product> AddAsync(Product product)
    {
        _storage.Add(product);
        return Task.FromResult(product);
    }
}
