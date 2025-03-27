using MauiApp1.UI.Views;
using MauiApp1.UI.ViewModels;

namespace MauiApp1.UI;

public partial class App : Microsoft.Maui.Controls.Application
{
	public App(MainViewModel mainViewModel)
	{
		InitializeComponent();

		// Establece MainPage a la vista que muestra el ViewModel
		MainPage = new MainPage(mainViewModel); // Aquí estamos pasando el ViewModel al constructor de la MainPage
	}
}
