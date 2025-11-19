using LifeManagementApp.Interfaces;
using LifeManagementApp.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace LifeManagementApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
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

            builder.Services.AddHttpClient<IJokeService, JokeApiService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<JokePage>();
            builder.Services.AddSingleton<INoteService, NoteService>();
            builder.Services.AddTransient<NotePage>();

            builder.Services.AddDbContext<AppDbContext>();

            return builder.Build();
        }
    }
}