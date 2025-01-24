using PassManager.model;
using System;
using System.Collections.Generic;
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

namespace PassManager
{
    /// <summary>
    /// Interaction logic for CreatePassItem.xaml
    /// </summary>
    public partial class CreatePassItem : Window
    {

        private MainWindow _mainWindow;

        public CreatePassItem(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            txtb_senha.Text = passb_senha.Password;
            passb_senha.Visibility = Visibility.Collapsed;
            txtb_senha.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            passb_senha.Password = txtb_senha.Text;
            passb_senha.Visibility = Visibility.Visible;
            txtb_senha.Visibility = Visibility.Collapsed;
        }

        private void btn_Conf_Click(object sender, RoutedEventArgs e) {

            using (var context = new PassManagerDbContext(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))) {

                string passtmp;
                bool show_hidetmp;

                if (ChkBox.IsChecked == true) {
                    passtmp = txtb_senha.Text;
                    show_hidetmp = true;
                }
                else {
                    passtmp = passb_senha.Password;
                    show_hidetmp = false;
                }

                context.Add(new Password_item {

                    descricao = txtb_descricao.Text,
                    password = passtmp,
                    show_hide = show_hidetmp

                });

                context.SaveChanges();
                _mainWindow.ListPasswordItems();
                this.Close();


            }
        }
    }
}
