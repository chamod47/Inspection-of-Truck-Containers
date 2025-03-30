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
    /// Interaction logic for DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

            MessageBox.Show("Logout Successfully!");
        }

        private void TxtTruck_Click(object sender, RoutedEventArgs e)
        {
            TruckInformtionWindow truckInformtionWindow = new TruckInformtionWindow();
            truckInformtionWindow.Show();
            this.Close();
        }

        private void TxtInspection_Click(object sender, RoutedEventArgs e)
        {
            InspectionDetailWindow inspectionDetailWindow= new InspectionDetailWindow();
            inspectionDetailWindow.Show();
            this.Close();
        }

        private void TxtSafety_Click(object sender, RoutedEventArgs e)
        {
            SafetyMecanicalInspectionWindow safetyMecanicalInspectionWindow=new SafetyMecanicalInspectionWindow();
            safetyMecanicalInspectionWindow.Show(); 
            this.Close();
        }

        private void TxtCargo_Click(object sender, RoutedEventArgs e)
        {
            CargoLoadInspectionWindow cargoLoadInspectionWindow = new CargoLoadInspectionWindow();
            cargoLoadInspectionWindow.Show();
            this.Close();
        }

        private void TxtLegal_Click(object sender, RoutedEventArgs e)
        {
            LegalComplianceCheckWindow legalComplianceCheckWindow = new LegalComplianceCheckWindow();
            legalComplianceCheckWindow.Show();
            this.Close();
        }

        private void TxtRecommendtion_Click(object sender, RoutedEventArgs e)
        {
            InspectionOutcomesWindow inspectionOutcomesWindow=new InspectionOutcomesWindow();
            inspectionOutcomesWindow.Show();
            this.Close();
        }

        private void TxtData_Click(object sender, RoutedEventArgs e)
        {
            ReportsDataManagementWindow reportsDataManagementWindow=new ReportsDataManagementWindow();
            reportsDataManagementWindow.Show();
            this.Close();
        }
    }
}
