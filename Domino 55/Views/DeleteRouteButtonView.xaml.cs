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
    /// Interaction logic for DeleteRouteButtonView.xaml
    /// </summary>
    public partial class DeleteRouteButtonView : TwoStepButtonView
    {
        private DeleteRouteButtonController controller;

        public override DeleteRouteButtonController Controller() => controller;

        public void BindController(DeleteRouteButtonController controller) => this.controller = controller;
        public DeleteRouteButtonView()
        {
            InitializeComponent();
        }
    }
}
