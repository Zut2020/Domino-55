using Domino_55.Controller;
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
    /// Interaction logic for ArrivalSignalView.xaml
    /// </summary>
    public partial class ArrivalSignalView : TwoStepButtonView
    {
        private ArrivalSignalController controller;

        public override ArrivalSignalController Controller() => controller;

        public void BindController(ArrivalSignalController controller) => this.controller = controller;
        public ArrivalSignalView()
        {
            InitializeComponent();
        }
    }
}
