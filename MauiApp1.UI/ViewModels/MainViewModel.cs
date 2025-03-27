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
    private readonly IMediator _mediator;
    public ObservableCollection<Product> Products { get; } = new();

    private string _productName = "";
    public string ProductName
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    private decimal _productPrice;
    public decimal ProductPrice
    {
        get => _productPrice;
        set => SetProperty(ref _productPrice, value);
    }

    public ICommand AddProductCommand { get; }

    public MainViewModel(IMediator mediator)
    {
        _mediator = mediator;
        AddProductCommand = new RelayCommand(async () => await AddProductAsync());
        InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        Products.Clear();
        foreach (var product in products) Products.Add(product);
    }

    private async Task AddProductAsync()
    {
        if (string.IsNullOrWhiteSpace(ProductName) || ProductPrice <= 0) return;

        var newProduct = await _mediator.Send(new AddProductCommand(ProductName, ProductPrice));
        Products.Add(newProduct);
        ProductName = string.Empty;
        ProductPrice = 0;
    }
}
