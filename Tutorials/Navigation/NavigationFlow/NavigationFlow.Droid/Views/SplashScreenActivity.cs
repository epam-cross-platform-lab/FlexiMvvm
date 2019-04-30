using Android.App;
using FlexiMvvm.Views;
using NavigationFlow.Core.ViewModels;

namespace NavigationFlow.Droid.Views
{
    [Activity(Label = "SplashScreenActivity", NoHistory = true, MainLauncher = true)]
    internal sealed class SplashScreenActivity : AppCompatActivity<EntryViewModel>
    {
    }
}