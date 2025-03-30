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
    /// Interaction logic for SafetyMecanicalInspectionWindow.xaml
    /// </summary>
    public partial class SafetyMecanicalInspectionWindow : Window
    {
        public SafetyMecanicalInspectionWindow()
        {
            InitializeComponent();
        }

        private void SaveInspectionButton_Click(object sender, RoutedEventArgs e)
        {
            String brakesCondition=BrakesConditionComboBox.SelectedItem?.ToString();

            String engineCondition=EngineConditionComboBox.SelectedItem?.ToString();


            MessageBox.Show($"Safety Inspection Saved: Breakes-{brakesCondition}, Engine-{engineCondition}");        
        }
    }
}
