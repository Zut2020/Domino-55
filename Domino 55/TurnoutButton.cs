using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Domino_55
{
    internal class TurnoutButton : DominoButton
    {
        public override void Action(DominoButton otherButton)
        {
            char chnum = Name.ToCharArray()[3];
            int number = int.Parse(chnum.ToString());
            
            //base.Action(otherButton);
            if (otherButton.GetType() == typeof(TurnoutCommonButton))
                TurnoutStepper.Instance.SetTurnout(number, Turnout.Direction.Common);
        }

        public override void press()
        {
            pressed = true;

            Grid grid = this.Content as Grid;

            Image image = new Image
            {
                Source = new BitmapImage(new Uri("/Domino 55;component/img/nyomott.png", UriKind.Relative))
            };

            image.Style = (Style)FindResource("imgStylePressed2");

            grid.Children.Add(image);
        }
    }
}
