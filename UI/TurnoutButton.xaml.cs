using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Domino_55.Model;

namespace Domino_55.UI
{
    /// <summary>
    /// Interaction logic for TurnoutButton.xaml
    /// </summary>
    public partial class TurnoutButton : TwoStepButton
    {
        
        private int number;

        public int Number { get => number; set => number = value; }

        public override void Press()
        {
            Grid grid = this.Content as Grid;

            Image image = new Image
            {
                Source = new BitmapImage(new Uri("/UI/Images/pressed.png", UriKind.Relative))
            };

            image.Style = (Style)FindResource("imgStylePressed2");

            grid.Children.Add(image);
        }
        public override void Action(TwoStepButton otherButton)
        {
            //base.Action(otherButton);
            if (otherButton.GetType() == typeof(TurnoutCommonButton))
                Model.Model.Instance.SetTurnout(number, Turnout.Direction.Common);
        }
        public TurnoutButton()
        {
            InitializeComponent();
        }
    }
}
