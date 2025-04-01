using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
    /// Interaction logic for TruckInformtionWindow.xaml
    /// </summary>
    public partial class TruckInformtionWindow : Window
    {
        public TruckInformtionWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string truckRegNumber = TruckRegTextBox.Text;
            string truckType = (TruckTypeTextBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string makeModel = MakeTextBox.Text;
            string chassisNumber = ChassNumberTextBox.Text;
            string yearOfManufacture = YearTextBox.Text;
            string fuelType = (FuelTypeTextBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string ownerName = OwnerText.Text;
            string address = AddressText.Text;
            string contactNumber = ContactText.Text;

            if (string.IsNullOrEmpty(truckRegNumber) || string.IsNullOrEmpty(truckType) || string.IsNullOrEmpty(makeModel) ||
                string.IsNullOrEmpty(chassisNumber) || string.IsNullOrEmpty(yearOfManufacture) || string.IsNullOrEmpty(fuelType) ||
                string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(contactNumber))
            {
                MessageBox.Show("Please fill in all fields before saving.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TruckInspectionDB"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO TruckInformation (truck_reg_number, truck_type, make_model, chassis_number, " +
                                   "year_of_manufacture, fuel_type, owner_name, address, contact_number) " +
                                   "VALUES (@truckRegNumber, @truckType, @makeModel, @chassisNumber, @yearOfManufacture, " +
                                   "@fuelType, @ownerName, @address, @contactNumber)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@truckRegNumber", truckRegNumber);
                        command.Parameters.AddWithValue("@truckType", truckType);
                        command.Parameters.AddWithValue("@makeModel", makeModel);
                        command.Parameters.AddWithValue("@chassisNumber", chassisNumber);
                        command.Parameters.AddWithValue("@yearOfManufacture", yearOfManufacture);
                        command.Parameters.AddWithValue("@fuelType", fuelType);
                        command.Parameters.AddWithValue("@ownerName", ownerName);
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@contactNumber", contactNumber);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Truck information saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            this.Close();
        }
    }
}
