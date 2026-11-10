using Avalonia.Controls.Maui.Platform;
using Avalonia.Markup.Xaml;
using Microsoft.Maui.Hosting;

namespace WasmPlusSingleProject;

// The browser uses a single-view lifetime, so this head supplies its own app
// class instead of the one generated in WasmPlusSingleProject.
public class AvaloniaApp : MauiAvaloniaApplication
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp(true);
}
