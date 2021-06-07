using Foundation;
using UIKit;

namespace ShapeTransitions.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.Forms.FormsMaterial.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}