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
            string complianceStatus = (ComplianceStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(complianceStatus))
            {
                MessageBox.Show("Please select a compliance status.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TruckInspectionDB"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO LegalComplianceChecks (compliance_status) VALUES (@complianceStatus)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@complianceStatus", complianceStatus);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Compliance check saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
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
