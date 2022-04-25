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
using Domino_55.Controller;
using Domino_55.Views;

namespace Domino_55
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TwoStepButtonController> pressed = new List<TwoStepButtonController>();
        Domino55Controller d55 = new Domino55Controller();

        public MainWindow()
        {
            InitializeComponent();
            btn2.BindController(new TurnoutButtonContorller(2, btn2));
            btn4.BindController(new TurnoutButtonContorller(4, btn4));
            btn1.BindController(new TurnoutButtonContorller(1, btn1));
            d55.TurnoutFeedbackControllers.Add(new TurnoutFeedbackController(valto2));
            d55.TurnoutFeedbackControllers.Add(new TurnoutFeedbackController(valto4));
            d55.TurnoutFeedbackControllers.Add(new TurnoutFeedbackController(valto1));
            d55.BindTurnoutFeedbackControllers();
        }


        private void miNormal_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void miLarge_Checked(object sender, RoutedEventArgs e)
        {

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

        private void TwoStepButtonClick(object sender, RoutedEventArgs e)
        {
            TwoStepButtonView view = sender as TwoStepButtonView;
            TwoStepButtonController contorller = view.Controller();

            if (!contorller.Pressed)
            {
                contorller.Press();

                pressed.Add(contorller);

                if (pressed.Count == 2)
                {
                    pressed[0].Action(pressed[1]);
                }

                if (pressed.Count >= 2)
                {
                    foreach (var item in pressed)
                    {
                        item.Release();
                    }
                    pressed.Clear();
                }
            }
            else
            {
                contorller.Release();
                pressed.Remove(contorller);
            }
        }

        private void btnValtovisszajel_Click(object sender, RoutedEventArgs e)
        {
            d55.ToggleTurnoutFeedback();
        }
    }
}
