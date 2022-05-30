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
    /// Interaction logic for TrackFeedbackView.xaml
    /// </summary>
    public partial class TrackFeedbackStraightView : TrackFeedbackView
    {
        public TrackFeedbackStraightView()
        {
            InitializeComponent();
        }

        public override void Free()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/egyenesUres.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            }); ;
        }

        public override void Lock()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/egyenesLezart.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }

        public override void Occupy()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/egyenesFoglalt.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }

        public override void Release()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/Domino 55;component/img/egyenesUres.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }
    }
}
