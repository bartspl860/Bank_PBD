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

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            var loginpage = new LoginPage();
            NavigationService.Navigate(loginpage);
        }

        private void btnStaffLogin_Click(object sender, RoutedEventArgs e)
        {
            var admPanel = new AdminPanel();
            NavigationService.Navigate(admPanel);
        }
    }
}
