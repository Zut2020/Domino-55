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
using Domino_55.Controller;

namespace Domino_55.Views
{
    /// <summary>
    /// Interaction logic for TurnoutButtonView.xaml
    /// </summary>
    public partial class TurnoutButtonView : TwoStepButtonView
    {
        private TurnoutButtonContorller contorller;

        public TurnoutButtonContorller Contorller { get => contorller; set => contorller = value; }

        public void BindController(TurnoutButtonContorller contorller) => this.Contorller = contorller;

        public TurnoutButtonView()
        {
            InitializeComponent();
            this.Style = FindResource("valami") as Style;
        }
    }
}
