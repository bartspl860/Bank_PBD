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
using Bank_PBD.Actions;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();

            
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (Actions.Validation.Register(
                tbxLoginRegister.Text,
                tbxPasswordRegister.Text,
                tbxNameRegister.Text,
                tbxSurnameRegister.Text))
            {
                //stkLoginPanel.Visibility = Visibility.Collapsed;
                //frmLoginPage.Content = new Transactions();
            }
        }
    }
}
