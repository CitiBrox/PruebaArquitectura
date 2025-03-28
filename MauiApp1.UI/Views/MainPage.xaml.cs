using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.UI.Messages;
using MauiApp1.UI.ViewModels;

namespace MauiApp1.UI.Views;

public partial class MainPage : ContentPage, IRecipient<ShowModalMessage>
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel; // Establecemos el ViewModel en el BindingContext

        // Regístralo para recibir el mensaje
        WeakReferenceMessenger.Default.Register<ShowModalMessage>(this);
    }

    public void Receive(ShowModalMessage msj)
    {
        DisplayAlert("Mensaje de Sistema", msj.Message, "Ok");
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WeakReferenceMessenger.Default.Unregister<ShowModalMessage>(this); 
    }
    
    private void OnNumberChanged(object sender, TextChangedEventArgs e)
    {
        // Permite el campo vacío
        if (string.IsNullOrEmpty(e.NewTextValue))
            return;

        // Validación de números
        if (!decimal.TryParse(e.NewTextValue, out _))
        {
            // Si no es un número válido, restaura el valor anterior
            ((Entry)sender).Text = e.OldTextValue;
            DisplayAlert("Error", "Solo se permiten números válidos", "OK");
        }
    }
}
