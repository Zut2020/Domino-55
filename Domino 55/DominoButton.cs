﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Domino_55
{
    internal class DominoButton : System.Windows.Controls.Button
    {
        protected bool pressed = false;

        public bool Pressed
        {
            get { return pressed; }
            private set { pressed = value; }
        }

        public void toggle()
        {
            if (pressed)
                release();
            else
                press();
        }

        public virtual void press()
        {
            pressed = true;

            Grid grid = this.Content as Grid;

            Image image = new Image
            {
                Source = new BitmapImage(new Uri("/Domino 55;component/img/nyomott.png", UriKind.Relative))
            };

            image.Style = (Style)FindResource("imgStylePressed");

            grid.Children.Add(image);
        }

        public void release()
        {
            pressed = false;

            Grid grid = this.Content as Grid;

            grid.Children.RemoveAt(1);
        }

        public virtual void Action(DominoButton otherButton)
        {
            try
            {
                throw new NotImplementedException("DominoButton Action()");
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
