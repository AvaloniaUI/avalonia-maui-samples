using Microsoft.Extensions.Logging;

namespace WaylandSupport;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp(bool useSingleViewLifetime = false)
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
#if !IOS && !MACCATALYST && !ANDROID && !WINDOWS
			.UseAvaloniaApp(useSingleViewLifetime)
#else
			.UseAvaloniaEmbedding<AvaloniaApp>()
#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
