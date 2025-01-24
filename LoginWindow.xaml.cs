using PassManager.model;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PassManager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            using (var context  = new PassManagerDbContext(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))) {

                List<Account> accounts = context.account.ToList();

                for(int i = 0; i < accounts.Count; i++) {

                    if (accounts[i].usr == usr_txt.Text && accounts[i].password == pass_txt.Password) {
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                        return;
                    }


                }

                MessageBox.Show("User NOT Found!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }
    }
}