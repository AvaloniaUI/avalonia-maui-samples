using Avalonia;

namespace WaylandSupport;

// Entry point for the Avalonia desktop head (net11.0). This replaces the Main that
// Avalonia.Controls.Maui.Desktop generates (AvaloniaControlsMauiGenerateDesktopProgram=false).
internal static class Program
{
	[STAThread]
	public static void Main(string[] args) => BuildAvaloniaApp()
		.StartWithClassicDesktopLifetime(args);

	public static AppBuilder BuildAvaloniaApp()
		=> AppBuilder.Configure<AvaloniaApp>()
			// Picks the platform backend: Win32 on Windows, Avalonia.Native on macOS, X11 on Linux.
			.UsePlatformDetect()
			// On Linux, use the Wayland backend when a Wayland compositor is available.
			// Otherwise keep X11. On Windows and macOS this call does nothing.
			.UseWaylandWithFallback()
			// Optional. The Wayland app id (xdg_toplevel.set_app_id) defaults to the entry
			// assembly name. Set it to match the name of the app's .desktop file.
			.With(new WaylandPlatformOptions { AppId = "com.companyname.waylandsupport" })
			.WithInterFont()
			.LogToTrace();
}
