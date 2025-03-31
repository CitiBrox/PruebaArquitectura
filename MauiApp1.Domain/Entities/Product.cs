namespace MauiApp1.Domain.Entities;

/// <summary>
/// Representa un producto en el catálogo.
/// </summary>
public class Product
{
    public Guid Id { get; set; }            // Identificador único
    public string Name { get; set; } = "";  // Nombre del producto
    public decimal Price { get; set; }      // Precio del producto

    public Product()
    {
        Id = Guid.NewGuid();
    }
}
