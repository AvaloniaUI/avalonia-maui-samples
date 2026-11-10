# WaylandSupport

This project shows how to add [Avalonia.Wayland](https://www.nuget.org/packages/Avalonia.Wayland) support to a .NET MAUI app that uses Avalonia.Controls.Maui.

On Linux, the Avalonia desktop head (`net11.0`) uses X11 by default. With this change, it uses Wayland when a Wayland compositor is available, and X11 when not. On Windows and macOS, nothing changes.

## Changes from the template

1. `WaylandSupport.csproj` adds the `Avalonia.Wayland` package to the `net11.0` target framework:

   ```xml
   <ItemGroup Condition="'$(TargetFramework)' == 'net11.0'">
     <PackageReference Include="Avalonia.Wayland" Version="$(AvaloniaVersion)" />
   </ItemGroup>
   ```

   Use the same version as the other Avalonia packages.

2. `WaylandSupport.csproj` turns off the generated desktop `Main`:

   ```xml
   <AvaloniaControlsMauiGenerateDesktopProgram>false</AvaloniaControlsMauiGenerateDesktopProgram>
   ```

3. `Platforms/Desktop/Program.cs` is the new desktop entry point:

   ```csharp
   public static AppBuilder BuildAvaloniaApp()
       => AppBuilder.Configure<AvaloniaApp>()
           .UsePlatformDetect()
           .UseWaylandWithFallback()
           .With(new WaylandPlatformOptions { AppId = "com.companyname.waylandsupport" })
           .WithInterFont()
           .LogToTrace();
   ```

   `UseWaylandWithFallback()` must come after `UsePlatformDetect()`. To use Wayland with no X11 fallback, call `UseWayland()` instead.

   `WaylandPlatformOptions` is optional. `AppId` sets the Wayland app id, which compositors use to match the window to its `.desktop` file. The default is the entry assembly name.

4. `WaylandSupport.csproj` adds `Platforms/Desktop` to the `net11.0` build:

   ```xml
   <ItemGroup Condition="'$(TargetFramework)' == 'net11.0'">
     <MauiPlatformSpecificFolder Include="Platforms\Desktop\" />
   </ItemGroup>
   ```

   In a single project, MAUI compiles only the `Platforms/` folders that it knows (Android, iOS, MacCatalyst, Windows, Tizen). This item adds the `Desktop` folder for `net11.0` only.

## Run

```sh
dotnet run --project WaylandSupport -f net11.0
```

To check that the X11 fallback works in a Wayland session, start the app with a Wayland display that does not exist:

```sh
WAYLAND_DISPLAY=no-wayland dotnet run --project WaylandSupport -f net11.0
```
