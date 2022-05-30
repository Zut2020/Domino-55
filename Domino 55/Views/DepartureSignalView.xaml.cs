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
    /// Interaction logic for DepartureSignalView.xaml
    /// </summary>
    public partial class DepartureSignalView : TwoStepButtonView
    {
        private DepartureSignalController controller;

        public override DepartureSignalController Controller() => controller;

        public void BindController(DepartureSignalController controller) => this.controller = controller;

        public DepartureSignalView()
        {
            InitializeComponent();
        }
    }
}
