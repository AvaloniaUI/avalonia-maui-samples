namespace WasmPlusMultiProject.Browser;

public static class MauiProgram
{
	// The browser hosts the app in a single view, so this head always uses the
	// single-view lifetime. The generated AvaloniaApp calls this method.
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseSharedMauiApp()
			.UseAvaloniaApp(useSingleViewLifetime: true);

		return builder.Build();
	}
}
