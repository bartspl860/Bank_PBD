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
using Bank_PBD.Model;
using Bank_PBD.Actions;
using System.Data.SqlClient;
using System.Data;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy Login.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnRegisterNav_Click(object sender, RoutedEventArgs e)
        {
            stkLoginPanel.Visibility = Visibility.Collapsed;
            frmLoginPage.Content = new RegisterPage();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
              stkLoginPanel.Visibility = Visibility.Collapsed;
              frmLoginPage.Content = new Transactions();
            
           
        }
    }
}
