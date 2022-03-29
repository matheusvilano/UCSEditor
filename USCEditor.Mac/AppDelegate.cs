using AppKit;
using Foundation;
using UCSEditor;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace USCEditor.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
{
        NSWindow window;
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;

            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            window.Title = "UCS Editor";
            window.TitleVisibility = NSWindowTitleVisibility.Hidden;
            window.MinSize = new CoreGraphics.CGSize(700, 800);
        }

        public override NSWindow MainWindow
        {
            get { return window; }
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new App());
            base.DidFinishLaunching(notification);
        }
    }
}
