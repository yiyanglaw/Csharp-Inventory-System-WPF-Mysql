using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    public partial class Search : Window
    {
        private readonly MySqlConnection _connection;

        public Search()
        {
            InitializeComponent();

            // Connect to MySQL database
            string connectionString = "server=localhost;database=inventory;user=root;password=Yiyanglaw@2003";
            _connection = new MySqlConnection(connectionString);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection.Open();

                string query = "SELECT * FROM robots WHERE RobotID = @RobotID";
                MySqlCommand command = new MySqlCommand(query, _connection);
                command.Parameters.AddWithValue("@RobotID", SearchRobotIDTextBox.Text.Trim());

                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Clear previous items
                InventoryDataGrid.ItemsSource = null;
                InventoryDataGrid.Items.Clear();

                // Bind retrieved data to the InventoryDataGrid
                InventoryDataGrid.ItemsSource = dataTable.DefaultView;
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

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show(); // Open the DashboardWindow
            Close(); // Close the current window
        }

        private void SearchRobotIDTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear placeholder text when the textbox is clicked
            SearchRobotIDTextBox.Text = "";
        }
    }
}
