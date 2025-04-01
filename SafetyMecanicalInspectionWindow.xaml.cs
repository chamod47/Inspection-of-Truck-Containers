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
            string brakesCondition = (BrakesConditionComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string engineCondition = (EngineConditionComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(brakesCondition) || string.IsNullOrEmpty(engineCondition))
            {
                MessageBox.Show("Please select conditions for both brakes and engine.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TruckInspectionDB"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SafetyMechanicalInspection (brakes_condition, engine_condition) VALUES (@brakesCondition, @engineCondition)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@brakesCondition", brakesCondition);
                        command.Parameters.AddWithValue("@engineCondition", engineCondition);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Inspection data saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

            private void  BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWidow=new DashboardWindow();
            dashboardWidow.Show();
            this.Close();
        }

        }
    }

