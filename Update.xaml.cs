using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    public partial class Update : Window
    {
        private readonly MySqlConnection _connection;

        public Update()
        {
            InitializeComponent();

            // Connect to MySQL database
            string connectionString = "server=localhost;database=inventory;user=root;password=Yiyanglaw@2003";
            _connection = new MySqlConnection(connectionString);

            // Attach event handlers to clear placeholder text when textboxes are clicked
            RobotIDTextBox.GotFocus += TextBox_GotFocus;
            ModelTextBox.GotFocus += TextBox_GotFocus;
            SerialNumberTextBox.GotFocus += TextBox_GotFocus;
            ManufacturerTextBox.GotFocus += TextBox_GotFocus;
            TypeTextBox.GotFocus += TextBox_GotFocus;
            PayloadCapacityTextBox.GotFocus += TextBox_GotFocus;
            ReachTextBox.GotFocus += TextBox_GotFocus;
            DOFTextBox.GotFocus += TextBox_GotFocus;
            SensorsTextBox.GotFocus += TextBox_GotFocus;
            BatteryTypeTextBox.GotFocus += TextBox_GotFocus;
            BatteryCapacityTextBox.GotFocus += TextBox_GotFocus;
            CurrentLocationTextBox.GotFocus += TextBox_GotFocus;
            StatusTextBox.GotFocus += TextBox_GotFocus;
            LastMaintenanceDateTextBox.GotFocus += TextBox_GotFocus;
            NextMaintenanceDueTextBox.GotFocus += TextBox_GotFocus;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            Close();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection.Open();

                // Prepare the SQL UPDATE statement
                string query = "UPDATE robots SET Model = @Model, SerialNumber = @SerialNumber, Manufacturer = @Manufacturer, Type = @Type, PayloadCapacity = @PayloadCapacity, Reach = @Reach, DOF = @DOF, Sensors = @Sensors, BatteryType = @BatteryType, BatteryCapacity = @BatteryCapacity, CurrentLocation = @CurrentLocation, Status = @Status, LastMaintenanceDate = @LastMaintenanceDate, NextMaintenanceDue = @NextMaintenanceDue WHERE RobotID = @RobotID";

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

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Inventory info updated successfully!");

                    // Clear all textboxes
                    ClearTextBoxes();
                }
                else
                {
                    MessageBox.Show("New Inventory info added successfully!");
                }
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

        private void ClearTextBoxes()
        {
            // Clear text of all textboxes
            RobotIDTextBox.Text = "";
            ModelTextBox.Text = "";
            SerialNumberTextBox.Text = "";
            ManufacturerTextBox.Text = "";
            TypeTextBox.Text = "";
            PayloadCapacityTextBox.Text = "";
            ReachTextBox.Text = "";
            DOFTextBox.Text = "";
            SensorsTextBox.Text = "";
            BatteryTypeTextBox.Text = "";
            BatteryCapacityTextBox.Text = "";
            CurrentLocationTextBox.Text = "";
            StatusTextBox.Text = "";
            LastMaintenanceDateTextBox.Text = "";
            NextMaintenanceDueTextBox.Text = "";
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear placeholder text when a textbox is clicked
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                textBox.Text = "";
            }
        }
    }
}
