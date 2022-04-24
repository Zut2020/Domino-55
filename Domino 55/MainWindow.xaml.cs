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
            miDomInd.IsChecked = true;
            miNormal.IsChecked = true;
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

        private void miNormal_Checked(object sender, RoutedEventArgs e)
        {
            miLarge.IsChecked = false;
            foreach (var item in buttons)
            {
                item.Style = FindResource("buttonStyleNormal") as Style;
            }
        }

        private void miLarge_Checked(object sender, RoutedEventArgs e)
        {
            miNormal.IsChecked = false;
            foreach (var item in buttons)
            {
                item.Style = FindResource("buttonStyleLarge") as Style;
            }
        }

        private void miDomInd_Checked(object sender, RoutedEventArgs e)
        {
            miDomCon.IsChecked = false;
            miElpInd.IsChecked = false;
            miElpCon.IsChecked = false;
        }

        private void miDomCon_Checked(object sender, RoutedEventArgs e)
        {
            miDomInd.IsChecked = false;
            miElpInd.IsChecked = false;
            miElpCon.IsChecked = false;
        }

        private void miElpInd_Checked(object sender, RoutedEventArgs e)
        {
            miDomInd.IsChecked = false;
            miDomCon.IsChecked = false;
            miElpCon.IsChecked = false;
        }

        private void miElpCon_Checked(object sender, RoutedEventArgs e)
        {
            miDomInd.IsChecked = false;
            miDomCon.IsChecked = false;
            miElpInd.IsChecked = false;
        }
    }
}
