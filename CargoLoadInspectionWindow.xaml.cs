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
    /// Interaction logic for CargoLoadInspectionWindow.xaml
    /// </summary>
    public partial class CargoLoadInspectionWindow : Window
    {
        public CargoLoadInspectionWindow()
        {
            InitializeComponent();
        }

        private void SaveCargoInspectionButton_Click(object sender, RoutedEventArgs e)
        {
            String loadWeight = LoadWeigtTextbox.ToString();
            String cargoType= CargoTypeComboBox.SelectedItem?.ToString();

            MessageBox.Show("Cargo Inspection Saved: Load Weight-{loadWeight},Cargo Type-{cargoType}");
        }
    }
}
