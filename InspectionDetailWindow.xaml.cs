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
using MySql.Data.MySqlClient;

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
            string inspectionDate = InspectionDatePicker.SelectedDate?.ToString("yyyy-MM-dd");
            string inspectorName = InspectorNameTextBox.Text;
            string inspectorId = InspectorIdTextBox.Text;
            string location = LocationTextBox.Text;
            string inspectionType = (InspectionTypeTextBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(inspectionDate) || string.IsNullOrEmpty(inspectorName) ||
                string.IsNullOrEmpty(inspectorId) || string.IsNullOrEmpty(location) || string.IsNullOrEmpty(inspectionType))
            {
                MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TruckInspectionDB"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO InspectionDetails (inspection_date, inspector_name, inspector_id, location, inspection_type) " +
                                   "VALUES (@inspectionDate, @inspectorName, @inspectorId, @location, @inspectionType)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@inspectionDate", inspectionDate);
                        command.Parameters.AddWithValue("@inspectorName", inspectorName);
                        command.Parameters.AddWithValue("@inspectorId", inspectorId);
                        command.Parameters.AddWithValue("@location", location);
                        command.Parameters.AddWithValue("@inspectionType", inspectionType);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Inspection details saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
