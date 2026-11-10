using Avalonia;
using Avalonia.Browser;
using System.Threading.Tasks;

namespace WasmPlusSingleProject;

internal sealed partial class Program
{
    private static Task Main(string[] args) => BuildAvaloniaApp()
            .WithInterFont()
            .StartBrowserAppAsync("out");

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<AvaloniaApp>();
}
