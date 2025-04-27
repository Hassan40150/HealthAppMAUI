using Android.App;
using Android.Content.PM;
using Android.OS;
using AndroidX.Core.View;


namespace HealthAppMAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {



        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var window = this.Window;
            if (window != null)
            {
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Lollipop)
                {
                    window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#121212"));
                    window.SetNavigationBarColor(Android.Graphics.Color.ParseColor("#121212"));
                }

                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
                {
                    var decorView = window.DecorView;
                    var wic = WindowCompat.GetInsetsController(window, decorView);
                    if (wic != null)
                    {

                        // Force WHITE icons on status bar (because background is black)
                        wic.AppearanceLightStatusBars = false;

                        // OPTIONAL: Keep navigation bar icons adapting to theme
                        var isDarkTheme = (Resources.Configuration.UiMode & Android.Content.Res.UiMode.NightMask) == Android.Content.Res.UiMode.NightYes;
                        wic.AppearanceLightNavigationBars = !isDarkTheme;
                    }
                }
            }
        }






    }
}
