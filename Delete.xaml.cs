using System;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    public partial class Delete : Window
    {
        private readonly MySqlConnection _connection;

        public Delete()
        {
            InitializeComponent();

            // Connect to MySQL database
            string connectionString = "server=localhost;database=inventory;user=root;password=Yiyanglaw@2003";
            _connection = new MySqlConnection(connectionString);

            // Attach event handler to clear placeholder text when textbox is clicked
            RobotIDTextBox.GotFocus += RobotIDTextBox_GotFocus;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection.Open();

                // Prepare the SQL DELETE statement
                string query = "DELETE FROM robots WHERE RobotID = @RobotID";

                MySqlCommand command = new MySqlCommand(query, _connection);

                // Add parameter value for RobotID
                command.Parameters.AddWithValue("@RobotID", RobotIDTextBox.Text);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Inventory info deleted successfully!");
                }
                else
                {
                    MessageBox.Show("No inventory info found with the given RobotID.");
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

        private void RobotIDTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear placeholder text when textbox is clicked
            RobotIDTextBox.Text = "";
        }
    }
}
