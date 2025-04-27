using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Handlers;
using Microsoft.Maui.Handlers;
#if ANDROID
using Android.Webkit;
using Android.Net.Http;
#endif

namespace HealthAppMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

#if ANDROID
            // 👇 Ignore SSL certificate errors inside WebView (ONLY FOR DEVELOPMENT)
            Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("AllowSSL", (handler, view) =>
            {
                handler.PlatformView.SetWebViewClient(new DevWebViewClient());
            });
#endif

            return builder.Build();
        }
    }

#if ANDROID
    // 👇 Custom WebViewClient that ignores SSL errors
    class DevWebViewClient : WebViewClient
    {
       
    public override void OnReceivedSslError(Android.Webkit.WebView? view, SslErrorHandler? handler, SslError? error)
{
    handler?.Proceed(); // Ignore all certificate errors
}
    }
#endif
}
