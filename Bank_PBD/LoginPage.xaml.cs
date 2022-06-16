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
using Bank_PBD.Storage;

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

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = tbxLogin.Text;
            var password = tbxPassword.Password;


            var loading = new Loading();
            
            loading.Show();            
            var result = await Actions.Validation.LoginAsync(login, password, Actions.Validation.UserType.CLIENT);
            loading.Hide();

            if (!result)
            {
                MessageBox.Show($"Podane dane są niepoprawne");
                tbxLogin.Clear();
                tbxPassword.Clear();
                return;
            }

           
            var trans = new Transactions();
            NavigationService.Navigate(trans);
        }

        private void btnStaffLoginPage_Click(object sender, RoutedEventArgs e)
        {
            var stafflogin = new StaffLoginPage();
            NavigationService.Navigate(stafflogin);
        }
    }
}
