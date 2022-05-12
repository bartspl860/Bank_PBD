using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Logika interakcji dla klasy Wewnetrzne.xaml
    /// </summary>
    public partial class Wewnetrzne : Page
    {
        public Wewnetrzne()
        {
            InitializeComponent();
        }

        private void btnSubmitInternalTransfers_Click(object sender, RoutedEventArgs e)
        {
            //using (SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Bank;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {

            }     
        }
    }
}
