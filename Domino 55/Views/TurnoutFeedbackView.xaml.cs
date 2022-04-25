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

namespace Domino_55.Views
{
    /// <summary>
    /// Interaction logic for TurnoutFeedbackView.xaml
    /// </summary>
    public partial class TurnoutFeedbackView : UserControl
    {
        public TurnoutFeedbackView()
        {
            InitializeComponent();
        }

        internal void SetDivergent()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/valtoKitero.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }

        public void SetStraight()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/valtoEgyenes.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }

        internal void SetOff()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/valtoUres.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }
    }
}
