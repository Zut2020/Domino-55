using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace Domino_55.UI
{
    public abstract class TwoStepButton : Button
    {
        protected bool pressed = false;

        public bool Pressed
        {
            get { return pressed; }
            private set { pressed = value; }
        }
        public virtual void Press()
        {
            pressed = true;

            Grid grid = this.Content as Grid;

            Image image = new Image
            {
                Source = new BitmapImage(new Uri("/UI/Images/pressed.png", UriKind.Relative))
            };

            image.Style = (Style)FindResource("imgStylePressed");

            grid.Children.Add(image);
        }

        public void Release()
        {
            pressed = false;

            Grid grid = this.Content as Grid;

            grid.Children.RemoveAt(1);
        }

        public abstract void Action(TwoStepButton otherButton);
    }
}
