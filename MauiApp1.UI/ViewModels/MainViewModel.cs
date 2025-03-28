using System.Collections.ObjectModel;
using System.Windows.Input;
using MediatR;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Commands;
using MauiApp1.Application.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiApp1.UI.ViewModels;

/// <summary>
/// ViewModel principal de la aplicación.
/// </summary>
public class MainViewModel : ObservableObject
{
    
    private readonly ProductService _productService;

    // Usamos ObservableCollection para los productos
    public ObservableCollection<Product> Products { get; } = new();

    // Usamos la entidad Product para representar el producto actual
    private Product _currentProduct = new Product();
    public Product CurrentProduct
    {
        get => _currentProduct;
        set => SetProperty(ref _currentProduct, value);
    }

    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public ICommand AddProductCommand { get; }

    public MainViewModel(ProductService productService)
    {
        _productService = productService;
        AddProductCommand = new RelayCommand(async () => await AddProductAsync());
        InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        try
        {
            IsLoading = true;
            var products = await _productService.GetAllProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }
        catch (Exception ex)
        {
            ErrorMessage = "Error al cargar los productos.";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private async Task AddProductAsync()
    {
        IsLoading = true;

        try
        {
            // Validamos si el producto es válido
            if (string.IsNullOrWhiteSpace(CurrentProduct.Name) || CurrentProduct.Price <= 0)
            {
                ErrorMessage = "El nombre del producto no puede estar vacío y el precio debe ser mayor que 0.";
                return;
            }

            // Usamos el servicio para agregar el producto
            var newProduct = await _productService.AddProductAsync(CurrentProduct.Name, CurrentProduct.Price);
            Products.Add(newProduct);

            // Limpiar campos después de agregar el producto
            ClearMessage();
        }
        catch (Exception ex)
        {
            ErrorMessage = "Error al agregar el producto";
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void ClearMessage() => (CurrentProduct, ErrorMessage) = (new Product(), string.Empty);

   

}
