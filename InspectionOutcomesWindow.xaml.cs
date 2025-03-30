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
    /// Interaction logic for InspectionOutcomesWindow.xaml
    /// </summary>
    public partial class InspectionOutcomesWindow : Window
    {
        public InspectionOutcomesWindow()
        {
            InitializeComponent();
        }

        private void SaveOutcomeButton_Click(object sender, RoutedEventArgs e)
        {
            String outcome=InspectionOutcomeComboBox.SelectedItem?.ToString();
            String recommendations = RecommendationTextBox.Text;

            MessageBox.Show($"Outcome Saved:{outcome}\n Recommendations:{recommendations}");
        }
    }
}
