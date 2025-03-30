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
            String truckRegistrationNumber = TruckRegTextBox.Text;

            String truckType= TruckTypeTextBox.SelectedItem?.ToString();

            String MakeModel=MakeTextBox.Text;

            String chassisNumber=ChassNumberTextBox.Text;

            String yearOfManufacture = YearTextBox.Text;

            String fuelType= FuelTypeTextBox.SelectedItem?.ToString();

            String truckOwnerName=OwnerText.Text;

            String address=AddressText.Text;

            String contactNumber=ContactText.Text;

            MessageBox.Show($"Truck Information Saved:{truckRegistrationNumber},{truckType},{MakeModel},{chassisNumber},{MakeModel},{yearOfManufacture},{fuelType},{truckOwnerName},{address},{contactNumber}");

        }
    }
}
