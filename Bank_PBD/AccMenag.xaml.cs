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
    /// Logika interakcji dla klasy AccMenag.xaml
    /// </summary>
    public partial class AccMenag : Page
    {
        public AccMenag()
        {
            InitializeComponent();
        }

        private void btnQuestiomMark_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Wybierz z listy konto które chcesz usunąć.\nPAMIĘTAJ konto nie może mieć dostępnych środków");
        }

        private void btnAddAcc_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
