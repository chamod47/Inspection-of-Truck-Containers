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
using System.Windows.Shapes;

namespace Custome_Department_Truck_Inspection_System
{
    /// <summary>
    /// Interaction logic for ReportsDataManagementWindow.xaml
    /// </summary>
    public partial class ReportsDataManagementWindow : Window
    {
        public ReportsDataManagementWindow()
        {
            InitializeComponent();
        }

        private void GenerateReportButton_click(object sender, RoutedEventArgs e)
        {
            String reportType=ReportTypeComboBox.SelectedItem?.ToString();

            MessageBox.Show("Report Generated:{reportType}");
        }
    }
}
