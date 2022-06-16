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
using Bank_PBD.Actions;
using static Bank_PBD.Actions.Validation;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy StaffLoginPage.xaml
    /// </summary>
    public partial class StaffLoginPage : Page
    {
        public StaffLoginPage()
        {
            InitializeComponent();
        }

        private async void btnStaffLogin_Click(object sender, RoutedEventArgs e)
        {
            var loading = new Loading();
            loading.Show();
            if (await Actions.Validation.LoginAsync(tbxLogin.Text, tbxPassword.Password, UserType.EMPLOYEE)){
                loading.Hide();
                var admPanel = new AdminPanel();
                NavigationService.Navigate(admPanel);
            }
            else
            {
                loading.Hide();
                MessageBox.Show("Logowanie nieudane");
                tbxLogin.Clear();
                tbxPassword.Clear();
            }
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            var back = new LoginPage();
            NavigationService.Navigate(back);
        }
    }
}
