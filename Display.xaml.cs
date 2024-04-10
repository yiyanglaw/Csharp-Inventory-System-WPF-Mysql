using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Window = System.Windows.Window;

namespace WpfApp1
{
    public partial class Display : Window
    {
        private readonly MySqlConnection _connection;

        public Display()
        {
            InitializeComponent();

            // Connect to MySQL database
            string connectionString = "server=localhost;database=inventory;user=root;password=Yiyanglaw@2003";
            _connection = new MySqlConnection(connectionString);
            LoadInventoryData();
        }

        private void LoadInventoryData()
        {
            try
            {
                _connection.Open();

                string query = "SELECT * FROM robots";
                MySqlCommand command = new MySqlCommand(query, _connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                InventoryDataGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error connecting to database: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }
        }

        private void ExportToExcelButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Application excelApp = new Application();
                if (excelApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }

                Workbook workbook = excelApp.Workbooks.Add();
                Worksheet worksheet = workbook.ActiveSheet;

                int row = 1;
                foreach (DataRowView item in InventoryDataGrid.Items)
                {
                    for (int i = 0; i < InventoryDataGrid.Columns.Count; i++)
                    {
                        worksheet.Cells[row, i + 1] = item[i];
                    }
                    row++;
                }

                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\inventory_data.xlsx";
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();

                MessageBox.Show("Inventory data exported to inventory_data.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardWindow dashboardWindow = new DashboardWindow();
            dashboardWindow.Show();
            Close();
        }
    }
}
