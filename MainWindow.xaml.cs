using DotNetEnv;
using PassManager.custom;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e) {
            base.OnInitialized(e);
            ListPasswordItems();
        }

        private void Criar_Click(object sender, RoutedEventArgs e) {
            CreatePassItem createPassItemWindow = new CreatePassItem(this);
            createPassItemWindow.Show();
        }

        private void Localizar_Click(object sender, RoutedEventArgs e) {
            LocalizarWindow localizarWindow = new LocalizarWindow(this, "Localizar");
            localizarWindow.Show();
        }

        private void Deletar_Click(object sender, RoutedEventArgs e) {
            LocalizarWindow deletarWindow = new LocalizarWindow(this, "Deletar");
            deletarWindow.Show();
        }

        public void ListPasswordItems() {

            using (var context = new PassManagerDbContext(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))) {

                List<Password_item> password_items = context.password_item.ToList();

                LBPassItems.Items.Clear();

                for (int i = 0; i < password_items.Count; i++) {

                    PasswordItem passwordItem = new PasswordItem();
                    
                    passwordItem.SetId(password_items[i].id);
                    passwordItem.SetDescription(password_items[i].descricao);
                    passwordItem.SetPassword(password_items[i].password);
                    passwordItem.SetChkBox(password_items[i].show_hide);

                    ListBoxItem item = new ListBoxItem { Content = passwordItem };

                    LBPassItems.Items.Add(item);

                }

            }


        }


    }
}
