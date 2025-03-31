using System.Collections.ObjectModel;
using System.Windows.Input;
using MediatR;
using MauiApp1.Domain.Entities;
using MauiApp1.Application.Commands;
using MauiApp1.Application.Queries;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.UI.Messages;
namespace MauiApp1.UI.ViewModels;

/// <summary>
/// ViewModel principal de la aplicación.
/// </summary>
public class MainViewModel : ObservableObject
{
    private readonly ProductService _productService;

    /// <summary>
    /// Usa ObservableCollection para los productos
    /// </summary>
    public ObservableCollection<Product> Products { get; } = new();

    /// <summary>
    /// Entidad Product para representar el producto actual
    /// </summary>
    private Product _currentProduct = new Product();
    public Product CurrentProduct
    {
        get => _currentProduct;
        set => SetProperty(ref _currentProduct, value);
    }

    /// <summary>
    /// Mensaje de error que se muestra en la interfaz cuando ocurre una excepción.
    /// </summary>
    private string _errorMessage;
    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    /// <summary>
    /// Indica si la aplicación está realizando una operación de carga o procesamiento.
    /// </summary>
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

    /// <summary>
    /// Método que inicializa la carga inicial de productos en el ViewModel.
    /// </summary>
    private async Task InitializeAsync()
    {
        await LoadProductsAsync();
    }

    /// <summary>
    /// Carga todos los productos disponibles desde el servicio de productos, 
    /// actualizando la colección observable para reflejarlos en la interfaz.
    /// </summary>
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
            SendMessage(ex.Message);
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// Agrega el producto actual (CurrentProduct) utilizando el servicio de productos.
    /// En caso de éxito, lo agrega a la colección observable para actualizar automáticamente la vista.
    /// </summary>
    private async Task AddProductAsync()
    {
        IsLoading = true;

        try
        {
            var newProduct = await _productService.AddProductAsync(CurrentProduct);
            Products.Add(newProduct);

            ClearMessage();
        }
        catch (Exception ex)
        {
            SendMessage(ex.Message);
        }
        finally
        {
            IsLoading = false;
        }
    }

    /// <summary>
    /// Limpia los campos de entrada y el mensaje de error en la interfaz después de una operación exitosa.
    /// </summary>
    private void ClearMessage() => (CurrentProduct, ErrorMessage) = (new Product(), string.Empty);

    /// <summary>
    /// Envía un mensaje usando el sistema de mensajería Weak Messaging (WeakReferenceMessenger),
    /// para mostrar notificaciones o modales en la interfaz de usuario.
    /// </summary>
    /// <param name="message">Texto del mensaje a mostrar en la interfaz.</param>
    private void SendMessage(string message) =>  
    WeakReferenceMessenger.Default.Send(new ShowModalMessage(message));

}
