using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Domino_55.Views
{
    public class TwoStepButtonView : Button
    {
        public void Press()
        {
            Grid grid = this.Content as Grid;

            Image image = new Image
            {
                Source = new BitmapImage(new Uri("/Domino 55;component/img/nyomott.png", UriKind.Relative))
            };

            image.Style = (Style)FindResource("imgStylePressed");

            grid.Children.Add(image);
        }

        public void Release()
        {
            Grid grid = this.Content as Grid;

            grid.Children.RemoveAt(1);
        }
    }
}