using MauiApp1.Domain.Entities;

namespace MauiApp1.Application.Interfaces;

/// <summary>
/// Interfaz para la persistencia de productos.
/// </summary>
public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();         // Obtiene todos los productos
    Task<Product> AddAsync(Product product);   // Agrega un nuevo producto
}
