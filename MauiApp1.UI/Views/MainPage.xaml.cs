using CommunityToolkit.Mvvm.Messaging;
using MauiApp1.UI.Messages;
using MauiApp1.UI.ViewModels;

namespace MauiApp1.UI.Views;

public partial class MainPage : ContentPage, IRecipient<ShowModalMessage>
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();

        // Establecemos el ViewModel en el BindingContext
        BindingContext = viewModel; 

        // Registro para recibir el mensaje
        WeakReferenceMessenger.Default.Register<ShowModalMessage>(this);
    }
    /// <summary>
    /// Método que se invoca cuando se recibe un mensaje de tipo ShowModalMessage.
    /// Muestra un mensaje de alerta con el contenido del mensaje recibido.
    /// </summary>
    /// <param name="msj">Mensaje de tipo ShowModalMessage que contiene el mensaje a mostrar.</param>
    /// <remarks>
    /// Este método es parte de la interfaz IRecipient y se invoca automáticamente
    /// cuando se recibe un mensaje de ese tipo.
    /// </remarks>
    /// <returns></returns>
    public void Receive(ShowModalMessage msj)
    {
        DisplayAlert("Mensaje de Sistema", msj.Message, "Ok");
    }

    /// <summary>
    /// Método invocado cuando la página está a punto de desaparecer de la pantalla.
    /// para liberar recursos o cancelar suscripciones realizadas anteriormente.
    /// </summary>
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        WeakReferenceMessenger.Default.Unregister<ShowModalMessage>(this); 
    }

    /// <summary>
    /// Evento que se activa cuando cambia el texto en un campo numérico (Entry).
    /// Realiza validación asegurando que solo se ingresen números válidos.
    /// Si el texto ingresado no es válido, restaura el valor anterior y muestra un mensaje de error.
    /// </summary>
    /// <param name="sender">El Entry que desencadenó el evento.</param>
    /// <param name="e">Argumentos del evento que contienen el texto nuevo y el anterior.</param>
    private void OnNumberChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(e.NewTextValue))
            return;

        if (!decimal.TryParse(e.NewTextValue, out _))
        {
            ((Entry)sender).Text = e.OldTextValue;
            DisplayAlert("Error", "Solo se permiten números válidos", "OK");
        }
    }
}
