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
using Domino_55.Controller;

namespace Domino_55.Views
{
    /// <summary>
    /// Interaction logic for TurnoutButtonView.xaml
    /// </summary>
    public partial class TurnoutButtonView : TwoStepButtonView
    {
        private TurnoutButtonContorller controller;

        public override TwoStepButtonController Controller() => controller;

        public void BindController(TurnoutButtonContorller controller) => this.controller = controller;

        public override void Press()
        {
            Grid grid = this.Content as Grid;

            Image image = new Image
            {
                Source = new BitmapImage(new Uri("/Domino 55;component/img/nyomott.png", UriKind.Relative))
            };

            image.Style = (Style)FindResource("imgStylePressed2");

            grid.Children.Add(image);
        }

        public TurnoutButtonView()
        {
            InitializeComponent();
            this.Style = FindResource("valami") as Style;
        }
    }
}
