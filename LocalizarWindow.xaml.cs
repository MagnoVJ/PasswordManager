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

namespace PassManager {
    /// <summary>
    /// Interaction logic for LocalizarWindow.xaml
    /// </summary>
    public partial class LocalizarWindow : Window {

        private MainWindow _mainWindow;
        private string _acao;

        public LocalizarWindow(MainWindow mainWindow, string acao) {
            InitializeComponent();
            _mainWindow = mainWindow;
            _acao = acao;
        }

        private void btn_Conf_Click(object sender, RoutedEventArgs e) {

            string codePassItem = txtb_codigo.Text;

            var listBox = _mainWindow.LBPassItems;

            List<Password_item> password_items = getPasswordListFromDB();

            for (int i = 0; i < listBox.Items.Count; i++) {

                if (password_items[i].id == Int32.Parse(codePassItem)) {

                    if (_acao == "Localizar") 
                        _mainWindow.LBPassItems.SelectedIndex = i;
                    else if (_acao == "Deletar") {

                        using (var context = new PassManagerDbContext(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))) {

                            var passItm = context.password_item.Find(Int32.Parse(codePassItem));

                            context.password_item.Remove(passItm);

                            context.SaveChanges();

                            MessageBox.Show("Item foi deletado!");

                            _mainWindow.ListPasswordItems();

                        }

                    }
                    this.Close();
                    return;

                }

            }

            MessageBox.Show("Item não pode ser encontrado!");
            this.Close();
  

        }

        private List<Password_item> getPasswordListFromDB() {

            using (var context = new PassManagerDbContext(Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"))) {

                return context.password_item.ToList();

            }
        }
    }
}
