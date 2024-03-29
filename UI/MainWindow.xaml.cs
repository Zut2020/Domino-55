﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Domino_55.UI;

namespace Domino_55
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TwoStepButton> pressed = new List<TwoStepButton>();
        private bool turnoutFeedback = false;
        private List<TurnoutFeedback> turnoutFeedbacks = new List<TurnoutFeedback>();
        public MainWindow()
        {
            InitializeComponent();

            turnoutFeedbacks.Add(valto1);
            turnoutFeedbacks.Add(valto2);
            turnoutFeedbacks.Add(valto4);

            UI.UI.Instance.mainWindow = this;

            setTurnoutFeedback(null, null);
        }

        public static void MsgBox(String msg)
        {
            MessageBox.Show(msg);
        }

        internal void StartTurnoutBlink(int number)
        {
            TurnoutFeedback feedback = turnoutFeedbacks.Find(x => x.Number == number);
            feedback.AntimateBlinkStart();
        }

        internal void StopTurnoutBlink(int number)
        {
            TurnoutFeedback feedback = turnoutFeedbacks.Find(x => x.Number == number);
            feedback.AnimateBlinkStop();
        }

        internal void LightRoute(char startSignal, char endSignal)
        {

        }

        

        internal void DarkenRoute(char startSignal, char endSignal)
        {

        }

        internal void setSignalFree(char signal)
        {

        }

        internal void setSignalStop(char signal)
        {

        }

        internal void setTurnoutFeedback(object sender, RoutedEventArgs e)
        {
            if (turnoutFeedback)
            {
                turnoutFeedback = false;
                foreach (TurnoutFeedback feedback in turnoutFeedbacks)
                {
                    feedback.FeedbackOFF();
                }
            }
            else
            {
                turnoutFeedback = true;
                foreach (TurnoutFeedback feedback in turnoutFeedbacks)
                {
                    feedback.FeedbackON();
                }
            }
        }

        private void TwoStepButtonClick(object sender, RoutedEventArgs e)
        {
            TwoStepButton button = sender as TwoStepButton;

            if (!button.Pressed)
            {
                button.Press();

                pressed.Add(button);

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
                button.Release();
                pressed.Remove(button);
            }
        }
    }
}
