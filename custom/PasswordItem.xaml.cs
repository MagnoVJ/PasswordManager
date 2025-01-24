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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PassManager.custom
{
    /// <summary>
    /// Interaction logic for PasswordItem.xaml
    /// </summary>
    public partial class PasswordItem : UserControl
    {
        public PasswordItem()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            tbx_passPassword.Text = passb_senha.Password;
            passb_senha.Visibility = Visibility.Collapsed;
            tbx_passPassword.Visibility = Visibility.Visible;
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) {
            passb_senha.Password = tbx_passPassword.Text;
            passb_senha.Visibility = Visibility.Visible;
            tbx_passPassword.Visibility = Visibility.Collapsed;
        }

        public void SetId(int id) {
            tb_passIDCod.Text = id.ToString();
        }

        public void SetDescription(string description) {
            lb_passSysName.Content = description;
        }

        public void SetPassword(string password) {

            if(ChkBox.IsChecked == true) {

                tbx_passPassword.Text = password;
            }
            else {
                passb_senha.Password = password;
            }

        }

        public void SetChkBox(bool chkBox) {

            ChkBox.IsChecked = chkBox;
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e) {


            if(ChkBox.IsChecked == true) {

                Clipboard.SetText(tbx_passPassword.Text);

            }
            else
                Clipboard.SetText(passb_senha.Password);



        }

        private void btn_Save_Click(object sender, RoutedEventArgs e) {


            int idToUpdate = Int32.Parse(tb_passIDCod.Text);

            using (var context = new PassManagerDbContext("Server=localhost;Database=passmanager_db;User=root;Password=MySQLRoot80;")) {

                var passItem = context.password_item.FirstOrDefault(p => p.id == idToUpdate);

                if (ChkBox.IsChecked == true) {

                    passItem.password = tbx_passPassword.Text;

                }
                else
                    passItem.password = passb_senha.Password;

                context.SaveChanges();

                MessageBox.Show("Record updated successfully!");

                if (ChkBox.IsChecked == true) {

                    tbx_passPassword.Text = passItem.password;

                }
                else
                    passb_senha.Password = passItem.password;
            }


               


        }
    }
}
