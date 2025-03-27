using MauiApp1.UI.ViewModels;

namespace MauiApp1.UI.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Establecemos el ViewModel en el BindingContext
    }
}
