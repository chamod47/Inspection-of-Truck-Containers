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
            string inspectionStatus = (InspectionStatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string issuesIdentified = RecommendationTextBox.Text;
            string recommendedRepairs = RecommendTextBox.Text;
            string nextInspectionDue = DueDateTextBox.Text;

            if (string.IsNullOrEmpty(inspectionStatus) || string.IsNullOrEmpty(issuesIdentified) ||
                string.IsNullOrEmpty(recommendedRepairs) || string.IsNullOrEmpty(nextInspectionDue))
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
                    string query = "INSERT INTO InspectionOutcomes (inspection_status, issues_identified, recommended_repairs, next_inspection_due) " +
                                   "VALUES (@inspectionStatus, @issuesIdentified, @recommendedRepairs, @nextInspectionDue)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@inspectionStatus", inspectionStatus);
                        command.Parameters.AddWithValue("@issuesIdentified", issuesIdentified);
                        command.Parameters.AddWithValue("@recommendedRepairs", recommendedRepairs);
                        command.Parameters.AddWithValue("@nextInspectionDue", nextInspectionDue);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Inspection outcomes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InspectionOutcomeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
