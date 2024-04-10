using System.Windows;

namespace WpfApp1
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide current window
            Hide();

            // Open Add.xaml window
            Add addWindow = new Add();
            addWindow.ShowDialog(); // Use ShowDialog() instead of Show()
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide current window
            Hide();

            // Open Search.xaml window
            Search searchWindow = new Search();
            searchWindow.ShowDialog(); // Use ShowDialog() instead of Show()
        }

        private void DisplayButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide current window
            Hide();

            // Open Display.xaml window
            Display displayWindow = new Display();
            displayWindow.ShowDialog(); // Use ShowDialog() instead of Show()
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide current window
            Hide();

            // Open Update.xaml window
            Update updateWindow = new Update();
            updateWindow.ShowDialog(); // Use ShowDialog() instead of Show()
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Hide current window
            Hide();

            // Open Delete.xaml window
            Delete deleteWindow = new Delete();
            deleteWindow.ShowDialog(); // Use ShowDialog() instead of Show()
        }
    }
}
