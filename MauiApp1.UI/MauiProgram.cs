using Microsoft.Extensions.Logging;
using MauiApp1.UI.ViewModels;
using MauiApp1.Application.Commands;
using MauiApp1.Application.Interfaces;
using MauiApp1.Infrastructure.Repositories;
using MauiApp1.UI.Views;
using Microsoft.Maui.Controls.Hosting;

namespace MauiApp1.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Registra ViewModel y Página en el contenedor de dependencias
            builder.Services.AddTransient<MainViewModel>(); // Para inyectar el MainViewModel
            builder.Services.AddTransient<MainPage>(); // Para inyectar la MainPage
            builder.Services.AddSingleton<IProductRepository, ProductRepository>(); // Para el repositorio
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddProductCommand).Assembly)); // MediatR

            // Registra la aplicación MAUI
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug(); // Para la depuración
#endif

            return builder.Build(); // Devuelve la aplicación configurada
        }
    }
}
