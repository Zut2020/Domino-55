using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Domino_55.Views;

namespace Domino_55.Controller
{
    public abstract class TwoStepButtonController
    {
        private TwoStepButtonView view;

        public TwoStepButtonController(TwoStepButtonView view)
        {
            this.view = view;
        }

        protected bool pressed = false;

        public bool Pressed
        {
            get { return pressed; }
            private set { pressed = value; }
        }

        public void Press()
        {
            pressed = true;
            view.Press();
        }

        internal void Release()
        {
            pressed = false;
            view.Release();
        }

        public abstract void Action(TwoStepButtonController otherButton);

    }
}
