using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using UCSEditor.Core;

namespace UCSEditor
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new UCSView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
