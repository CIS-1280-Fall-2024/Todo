using Microsoft.Extensions.Logging;

namespace Todo
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
            Preferences.Clear();
            Preferences.Set("ConnectionString", "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Rob011235\\source\\repos\\Tutorials\\Todo\\Todo\\ToDoDB.mdf;Integrated Security=True;Connect Timeout=30");

            return builder.Build();
        }
    }
}
