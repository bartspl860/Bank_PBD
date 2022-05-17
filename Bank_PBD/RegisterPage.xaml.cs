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
        private async void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var loading = new Loading();
            loading.Show();

            var result = await Actions.Validation.RegisterAsync(
                tbxLoginRegister.Text,
                tbxPasswordRegister.Password,
                tbxNameRegister.Text,
                tbxSurnameRegister.Text);

            loading.WaitForLoad();

            if (result.Item1)
            {
                stkRegisterPanel.Visibility = Visibility.Collapsed;                
                frmRegisterPage.Content = new Transactions();
            }
            else
            {
                MessageBox.Show(result.Item2);
            }
        }
    }
}
