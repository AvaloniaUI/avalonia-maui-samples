# WasmPlusSingleProject

This project demostrates adding a Avalonia.Browser project to a .NET MAUI and Avalonia.Controls.Maui project.

## Projects

- `WasmPlusSingleProject` is the .NET MAUI single project. It adds the `net11.0` (Avalonia desktop) and `net11.0-browser` target frameworks. For `net11.0-browser`, it builds as a library, not an executable.
- `WasmPlusSingleProject.Browser` is the WebAssembly head. It references the single project, supplies its own `AvaloniaApp` that calls `MauiProgram.CreateMauiApp(true)` (single-view lifetime), and starts the app in the `out` element of `wwwroot/index.html`.

## Run in the browser

```sh
dotnet run --project WasmPlusSingleProject.Browser
```

Then open the `App url` that the command prints.
