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
            string cargoType = (CargoTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string securityMechanism = (SecurityTextox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string weightLimitCompliance = LimitTextBox.Text;
            string hazardousDocs = DocTextBox.Text;

            if (string.IsNullOrEmpty(cargoType) || string.IsNullOrEmpty(securityMechanism) ||
                string.IsNullOrEmpty(weightLimitCompliance) || string.IsNullOrEmpty(hazardousDocs))
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
                    string query = "INSERT INTO CargoInspection (cargo_type, security_mechanism, weight_limit_compliance, hazardous_docs) " +
                                   "VALUES (@cargoType, @securityMechanism, @weightLimit, @hazardousDocs)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@cargoType", cargoType);
                        command.Parameters.AddWithValue("@securityMechanism", securityMechanism);
                        command.Parameters.AddWithValue("@weightLimit", weightLimitCompliance);
                        command.Parameters.AddWithValue("@hazardousDocs", hazardousDocs);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Cargo inspection saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
