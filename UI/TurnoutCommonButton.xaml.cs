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

namespace Domino_55.UI
{
    /// <summary>
    /// Interaction logic for TurnoutCommonButton.xaml
    /// </summary>
    public partial class TurnoutCommonButton : TwoStepButton
    {
        public TurnoutCommonButton()
        {
            InitializeComponent();
        }

        public override void Action(TwoStepButton otherButton)
        {
            otherButton.Action(this);
        }
    }
}
