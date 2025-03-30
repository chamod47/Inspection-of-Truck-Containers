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
    /// Interaction logic for InspectionDetailWindow.xaml
    /// </summary>
    public partial class InspectionDetailWindow : Window
    {
        public InspectionDetailWindow()
        {
            InitializeComponent();
        }

        private void SaveDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            String inspectionDate = InspectionDatePicker.SelectedDate?.ToString("d") ?? "Not Selected";
            
            String inspectorName=InspectorNameTextBox.Text; 

        }
    }
}
