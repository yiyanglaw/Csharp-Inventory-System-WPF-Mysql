using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for the "Forgot Your Password?" text block
        private void ForgotPassword_Click(object sender, MouseButtonEventArgs e)
        {
            // Handling forgotten password
            MessageBox.Show("Please contact your system administrator for assistance with your password.");
        }

        // Event handler for the Login button
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the username and password from the text boxes
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // Authenticate the user
            bool isAuthenticated = AuthenticateUser(username, password);

            // Check if authentication is successful
            if (isAuthenticated)
            {
                // If authenticated, open the DashboardWindow and close the login window
                DashboardWindow dashboardWindow = new DashboardWindow();
                dashboardWindow.Show();
                this.Close(); // Close the login window
            }
            else
            {
                // If authentication fails, show an error message
                MessageBox.Show("Invalid username or password. Please try again.");
            }
        }

        // Method to authenticate the user (replace with your actual authentication logic)
        private bool AuthenticateUser(string username, string password)
        {
            // Replace this logic with your actual authentication mechanism
            return username == "admin" && password == "admin";
        }

        // Event handler for when a textbox receives focus
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // Clear the text of the textbox when it receives focus
            TextBox textBox = sender as TextBox;
            textBox.Text = "";
        }
    }
}
