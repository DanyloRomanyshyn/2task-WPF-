using System.Windows;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp;
namespace WarehouseManagementApp.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Перевірка користувача
            string connectionString = "Host=localhost;Port=5432;Database=WarehouseDB;Username=postgres;Password=Wdhjkopz1!";
            var usersRepository = new UsersRepository(connectionString);
            var (role, isValid) = usersRepository.ValidateUser(username, password);

            if (isValid)
            {
                MessageBox.Show($"Welcome, {username}! Role: {role}", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);

                // Відкриваємо головне вікно
                MainWindow mainWindow = new MainWindow(role);
                mainWindow.Show();

                // Закриваємо вікно логіна
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }

}

