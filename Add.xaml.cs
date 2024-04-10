using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    public partial class Add : Window
    {
        private readonly MySqlConnection _connection;

        public Add()
        {
            InitializeComponent();

            // Connect to MySQL database
            string connectionString = "server=localhost;database=inventory;user=root;password=Yiyanglaw@2003";
            _connection = new MySqlConnection(connectionString);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection.Open();

                // Prepare the SQL INSERT statement
                string query = "INSERT INTO robots (RobotID, Model, SerialNumber, Manufacturer, Type, PayloadCapacity, Reach, DOF, Sensors, BatteryType, BatteryCapacity, CurrentLocation, Status, LastMaintenanceDate, NextMaintenanceDue) " +
                               "VALUES (@RobotID, @Model, @SerialNumber, @Manufacturer, @Type, @PayloadCapacity, @Reach, @DOF, @Sensors, @BatteryType, @BatteryCapacity, @CurrentLocation, @Status, @LastMaintenanceDate, @NextMaintenanceDue)";

                MySqlCommand command = new MySqlCommand(query, _connection);

                // Add parameter values from the input fields
                command.Parameters.AddWithValue("@RobotID", RobotIDTextBox.Text);
                command.Parameters.AddWithValue("@Model", ModelTextBox.Text);
                command.Parameters.AddWithValue("@SerialNumber", SerialNumberTextBox.Text);
                command.Parameters.AddWithValue("@Manufacturer", ManufacturerTextBox.Text);
                command.Parameters.AddWithValue("@Type", TypeTextBox.Text);
                command.Parameters.AddWithValue("@PayloadCapacity", PayloadCapacityTextBox.Text);
                command.Parameters.AddWithValue("@Reach", ReachTextBox.Text);
                command.Parameters.AddWithValue("@DOF", DOFTextBox.Text);
                command.Parameters.AddWithValue("@Sensors", SensorsTextBox.Text);
                command.Parameters.AddWithValue("@BatteryType", BatteryTypeTextBox.Text);
                command.Parameters.AddWithValue("@BatteryCapacity", BatteryCapacityTextBox.Text);
                command.Parameters.AddWithValue("@CurrentLocation", CurrentLocationTextBox.Text);
                command.Parameters.AddWithValue("@Status", StatusTextBox.Text);
                command.Parameters.AddWithValue("@LastMaintenanceDate", LastMaintenanceDateTextBox.Text);
                command.Parameters.AddWithValue("@NextMaintenanceDue", NextMaintenanceDueTextBox.Text);

                command.ExecuteNonQuery();

                MessageBox.Show("Inventory info added successfully!");

                // Clear the input fields
                ClearInputFields();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        private void ClearInputFields()
        {
            RobotIDTextBox.Text = string.Empty;
            ModelTextBox.Text = string.Empty;
            SerialNumberTextBox.Text = string.Empty;
            ManufacturerTextBox.Text = string.Empty;
            TypeTextBox.Text = string.Empty;
            PayloadCapacityTextBox.Text = string.Empty;
            ReachTextBox.Text = string.Empty;
            DOFTextBox.Text = string.Empty;
            SensorsTextBox.Text = string.Empty;
            BatteryTypeTextBox.Text = string.Empty;
            BatteryCapacityTextBox.Text = string.Empty;
            CurrentLocationTextBox.Text = string.Empty;
            StatusTextBox.Text = string.Empty;
            LastMaintenanceDateTextBox.Text = string.Empty;
            NextMaintenanceDueTextBox.Text = string.Empty;
        }
    }
}
