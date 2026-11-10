# WasmPlusMultiProject

This project demostrates adding a Avalonia.Browser project to a .NET MAUI multi-project application.

## Projects

- `WasmPlusMultiProject` is the shared library. It targets `net11.0` and holds the app, pages, styles, fonts and images. `UseSharedMauiApp()` registers them.
- `WasmPlusMultiProject.Desktop`, `.Droid`, `.iOS`, `.Mac` and `.WinUI` are the platform heads. Each head has its own `MauiProgram` and uses the `AvaloniaApp` that Avalonia.Controls.Maui generates.
- `WasmPlusMultiProject.Browser` is the WebAssembly head. It targets `net11.0-browser` and references the shared library. Its `MauiProgram.CreateMauiApp()` always uses the single-view lifetime that the browser needs, so the generated `AvaloniaApp` works without changes. `Program.cs` starts the app in the `out` element of `wwwroot/index.html`.

## Run in the browser

```sh
dotnet run --project WasmPlusMultiProject.Browser
```

Then open the `App url` that the command prints.
