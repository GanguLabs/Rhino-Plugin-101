﻿using Rhino_Plugin.ViewModels;
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
            MessageBox.Show(_generatePanelVM.LengthX.ToString());
        }
    }
}
