using Avalonia;
using Avalonia.Browser;

namespace WasmPlusMultiProject.Browser;

internal sealed partial class Program
{
	private static Task Main(string[] args) => BuildAvaloniaApp()
		.WithInterFont()
		.StartBrowserAppAsync("out");

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<AvaloniaApp>();
}
