using Microsoft.Extensions.Logging;
using MauiApp1.UI.ViewModels;
using MauiApp1.Application.Commands;
using MauiApp1.Application.Interfaces;
using MauiApp1.Infrastructure.Repositories;
using MauiApp1.UI.Views;
using Microsoft.Maui.Controls.Hosting;
using MauiApp1.Application.Service;

namespace MauiApp1.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Registra ViewModel y Página en el contenedor de dependencias
            builder.Services.AddTransient<MainViewModel>(); 
            builder.Services.AddTransient<MainPage>(); 
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<ProductService>();
            // Inyección de MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddProductCommand).Assembly)); 

            // Registra la aplicación MAUI
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            //Devuelve la aplicación configurada
            return builder.Build(); 
        }
    }
}
