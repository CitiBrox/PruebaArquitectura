namespace MauiApp1.Domain.Entities;

/// <summary>
/// Representa un producto en el catálogo.
/// </summary>
public class Product
{
    /// <summary>
    /// Identificador único
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Nombre del producto
    /// </summary>
    public string Name { get; set; } = "";
    /// <summary>
    /// Precio del producto
    /// </summary>
    public decimal Price { get; set; }

    public Product()
    {
        Id = Guid.NewGuid();
    }
}
