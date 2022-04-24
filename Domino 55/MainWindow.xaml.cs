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
using System.Windows.Media.Effects;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Domino_55
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable<DominoButton> buttons;
        public MainWindow()
        {
            InitializeComponent();
            buttons = gridMain.Children.OfType<DominoButton>();
        }

        private Button[] pressedButtons = new Button[2];

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            DominoButton btn = (DominoButton)sender;

            btn.toggle();

            int pressedButtons = 0;

            foreach (DominoButton button in buttons)
            {
                if (button.Pressed)
                    pressedButtons++;
            }

            if (pressedButtons == 2)
            {
                foreach (var item in buttons)
                {
                    if (item.Pressed)
                    {
                        item.Action();
                        break;
                    }
                }
            }

            if (pressedButtons >= 2)
            {
                foreach (var item in buttons)
                {
                    if (item.Pressed)
                    {
                        item.release(); 
                    }
                }
            }
        }
    }
}
