using Uno.Resizetizer;

namespace HelloWorld;
public partial class App : PrismApplication
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        this.InitializeComponent();
    }

    protected override UIElement CreateShell()
    {
        return Container.Resolve<Shell>();
    }

    protected override void ConfigureHost(IHostBuilder builder)
    {
        builder
#if DEBUG
            // Switch to Development environment when running in DEBUG
            .UseEnvironment(Environments.Development)
#endif
            .UseLogging(configure: (context, logBuilder) =>
            {
                // Configure log levels for different categories of logging
                logBuilder
                    .SetMinimumLevel(
                        context.HostingEnvironment.IsDevelopment() ?
                            LogLevel.Information :
                            LogLevel.Warning)

                    // Default filters for core Uno Platform namespaces
                    .CoreLogLevel(LogLevel.Warning);
            }, enableUnoLogging: true)
            .ConfigureServices((context, services) =>
            {
                // TODO: Register your services
                //services.AddSingleton<IMyService, MyService>();
            });
    }

    protected override void ConfigureWindow(Window window)
    {
#if DEBUG
        window.EnableHotReload();
#endif
        window.SetWindowIcon();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Register types with the container or for Navigation
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<ModuleAModule>();
    }
}
