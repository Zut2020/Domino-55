using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for TurnoutFeedback.xaml
    /// </summary>
    public partial class TurnoutFeedback : UserControl
    {
        private static System.Timers.Timer _timer;
        private const int delayTime = 500;
        private const int switchTime = 2500;
        private bool blinking = false;
        private bool feedback = false;
        private bool locked = false;
        private int number;

        public int Number { get => number; set => number = value; }

        public TurnoutFeedback()
        {
            InitializeComponent();
            SetTimer();
        }
        public void SetTimer()
        {
            _timer = new System.Timers.Timer(delayTime);
            _timer.Elapsed += Blink;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private bool blinkLight = false;

        private void Blink(object? sender, ElapsedEventArgs e)
        {
            Turnout.Direction direction = Model.Model.Instance.GetTurnoutDirection(Number);
            if (blinking)
            {
                if (direction == Turnout.Direction.Straight)
                {
                    if (!blinkLight)
                    {
                        SetStraight();
                    }
                    else
                    {
                        SetOff();
                    }
                }
                else
                {
                    if (!blinkLight)
                    {
                        SetBranch();
                    }
                    else
                    {
                        SetOff();
                    }
                }
            }
            blinkLight = !blinkLight;
        }

        public void Update()
        {
            Turnout.Direction direction = Model.Model.Instance.GetTurnoutDirection(Number);
            if (locked)
            {
                if (direction == Turnout.Direction.Straight)
                    LockStraight();
                else
                    SetBranch();
            }
            else if (feedback)
            {
                if (direction == Turnout.Direction.Straight)
                    SetStraight();
                else
                    SetBranch();
            }
            else
                SetOff();
        }

        public void FeedbackON()
        {
            feedback = true;
            Update();
        }

        public void FeedbackOFF()
        {
            feedback = false;
            Update();
        }

        public void Lock()
        {
            locked = true;
            Update();
        }

        public void Release()
        {
            locked = false;
            Update();
        }

        public void AntimateBlinkStart()
        {
            blinking = true;
            Update();
        }

        public void AnimateBlinkStop()
        {
            blinking = false;
            Update();
        }

        internal void SetBranch()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/UI/Images/turnoutBranch.png", UriKind.Relative))
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
                    Source = new BitmapImage(new Uri("/UI/Images/turnoutStraight.png", UriKind.Relative))
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
                    Source = new BitmapImage(new Uri("/UI/Images/turnoutEmpty.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }

        internal void LockStraight()
        {
            this.Dispatcher.Invoke(() =>
            {
                Grid grid = this.Content as Grid;

                Image image = new Image
                {
                    Source = new BitmapImage(new Uri("/UI/Images/turnoutLocked.png", UriKind.Relative))
                };

                grid.Children.Clear();
                grid.Children.Add(image);
            });
        }
    }
}
