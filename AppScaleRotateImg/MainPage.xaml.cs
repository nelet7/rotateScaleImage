using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace AppScaleRotateImg
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.imgTesla.ManipulationMode = ManipulationModes.Scale | ManipulationModes.Rotate;
        }

        private void imgTesla_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {

            CompositeTransform ct = new CompositeTransform();
            FrameworkElement source = (FrameworkElement)e.OriginalSource;

            ct.CenterX = source.Width / 2.0;
            ct.CenterY = source.Height / 2.0;

            ct.Rotation = 0;
            ct.ScaleX = 1.0;
            ct.ScaleY = 1.0;

            ct.ScaleX *= e.Delta.Scale;
            ct.ScaleY *= e.Delta.Scale;

            /*
            ct.TranslateX = ct.TranslateX + e.Delta.Translation.X;
            ct.TranslateY = ct.TranslateY + e.Delta.Translation.Y;
            */

            source.RenderTransform = ct;

        }
    }
}
