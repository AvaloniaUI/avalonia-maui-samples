namespace WasmPlusMultiProject.Mac;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseSharedMauiApp()
			.UseAvaloniaEmbedding<AvaloniaApp>();

		return builder.Build();
	}
}
