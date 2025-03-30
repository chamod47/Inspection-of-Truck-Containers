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
    /// Interaction logic for LegalComplianceCheckWindow.xaml
    /// </summary>
    public partial class LegalComplianceCheckWindow : Window
    {
        public LegalComplianceCheckWindow()
        {
            InitializeComponent();
        }

        private void SaveComplianceCheckButton_Click(object sender, RoutedEventArgs e)
        {
            String complianceStatus=ComplianceStatusComboBox.SelectedItem?.ToString();

            MessageBox.Show($"Compliance Check Saved:Status-{complianceStatus}");
        }
    }
}
