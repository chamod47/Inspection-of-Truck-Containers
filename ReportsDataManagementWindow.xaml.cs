using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    /// Interaction logic for ReportsDataManagementWindow.xaml
    /// </summary>
    public partial class ReportsDataManagementWindow : Window
    {
        public ReportsDataManagementWindow()
        {
            InitializeComponent();
        }

        /*private void GenerateReportButton_click(object sender, RoutedEventArgs e)
        {
            string reportType = (ReportTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a report type.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TruckInspectionDB"].ConnectionString;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Reports (report_type) VALUES (@reportType)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@reportType", reportType);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Report generated and saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }*/


        private void GenerateReportButton_click(object sender, RoutedEventArgs e)
        {
            string reportType = (ReportTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            string reportFileName = $"Inspection_Report_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
            string filePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), reportFileName);

            try
            {
                // Open the file for writing
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Print header for the report
                    writer.WriteLine("Inspection Report Generated on: " + DateTime.Now);
                    writer.WriteLine("=============================================");
                    writer.WriteLine();

                    // Retrieve and write CargoInspection data
                    writer.WriteLine("Cargo Inspection Data:");
                    var cargoInspectionData = GetTableData("CargoInspection");
                    WriteTableData(writer, cargoInspectionData);

                    writer.WriteLine();
                    writer.WriteLine("=============================================");

                    // Retrieve and write InspectionDetails data
                    writer.WriteLine("Inspection Details:");
                    var inspectionDetailsData = GetTableData("InspectionDetails");
                    WriteTableData(writer, inspectionDetailsData);

                    writer.WriteLine();
                    writer.WriteLine("=============================================");

                    // Retrieve and write InspectionOutcomes data
                    writer.WriteLine("Inspection Outcomes:");
                    var inspectionOutcomesData = GetTableData("InspectionOutcomes");
                    WriteTableData(writer, inspectionOutcomesData);

                    writer.WriteLine("=============================================");
                    writer.WriteLine("End of Report");

                    MessageBox.Show($"Report generated successfully! File saved to: {filePath}", "Report Generation", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Function to fetch data from the database for a given table
        private List<Dictionary<string, object>> GetTableData(string tableName)
        {
            List<Dictionary<string, object>> tableData = new List<Dictionary<string, object>>();

            string query = $"SELECT * FROM {tableName}";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TruckInspectionDB"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                // Read each row and store in a dictionary
                while (reader.Read())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row.Add(reader.GetName(i), reader.GetValue(i));
                    }
                    tableData.Add(row);
                }
            }

            return tableData;
        }

        // Function to write the data from the table to the file
        private void WriteTableData(StreamWriter writer, List<Dictionary<string, object>> tableData)
        {
            if (tableData.Count == 0)
            {
                writer.WriteLine("No data found.");
                return;
            }

            // Write column headers
            writer.WriteLine(string.Join("\t", tableData[0].Keys));

            // Write rows
            foreach (var row in tableData)
            {
                writer.WriteLine(string.Join("\t", row.Values));
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow=new DashboardWindow();
            dashboardWindow.Show();
            this.Close();
        }
    }
}
