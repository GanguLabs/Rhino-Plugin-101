using Rhino.Geometry;
using Rhino_Plugin.ViewModels;
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

namespace Rhino_Plugin.Views
{
    /// <summary>
    /// Interaction logic for GeneratePlane.xaml
    /// </summary>
    public partial class GeneratePlane : UserControl
    {
        private GeneratePanelVM _generatePanelVM;
        public GeneratePlane()
        {
            InitializeComponent();
            _generatePanelVM = new GeneratePanelVM();
            this.DataContext = _generatePanelVM;
        }

        private void btnGeneratePlate_Click(object sender, RoutedEventArgs e)
        {
            Point3d centerPoint = new Point3d(0, 0, 0);
            int lenX = int.Parse(_generatePanelVM.LengthX);
            int lenY = int.Parse(_generatePanelVM.LengthY);

            int xCoord = int.Parse(_generatePanelVM.XCoord);
            int yCoord = int.Parse(_generatePanelVM.YCoord);
            int zCoord = int.Parse(_generatePanelVM.ZCoord);
            centerPoint = new Point3d(xCoord, yCoord, zCoord);

            string genPlateScript = $"_-Generate_Plate {centerPoint.ToString()} {lenX.ToString()} {lenY.ToString()}";
            // reference: https://developer.rhino3d.com/guides/rhinocommon/run-rhino-command-from-plugin/
            Rhino.RhinoApp.RunScript(genPlateScript, false);

            // MessageBox.Show(_generatePanelVM.LengthX.ToString());
        }
    }
}
