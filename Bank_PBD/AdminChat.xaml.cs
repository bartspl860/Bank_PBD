using Bank_PBD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Bank_PBD.Storage;

namespace Bank_PBD
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class AdminChat : Window
    {
        private List<Client> clients;
        private Client selectedClient;
        public AdminChat()
        {
            InitializeComponent();
            using (var db = new DbBankContext())
            {
                var clientsThatTexted =
                    (from c in db.Clients
                     join m in db.InternalMessages
                     on c.Id equals m.ClientId
                     select c).Distinct();

                foreach (var client in clientsThatTexted)
                {
                    lbxClients.Items.Add($"{client.Id}: {client.Name} {client.Surname}");
                }

                clients = clientsThatTexted.ToList();
            }            
        }

        private void ReloadChat()
        {
            lbxMessagesContent.Items.Clear();
            int index = lbxClients.SelectedIndex;
            if (index < 0)
                return;
            selectedClient = clients[index];


            using (var db = new DbBankContext())
            {
                var messages = db.InternalMessages
                    .Where(m => m.ClientId == selectedClient.Id)
                    .Select(m => m)
                    .OrderBy(m => m.Date);

                foreach (var message in messages)
                {
                    var whoSend = (message.ClientSend) ? "Ty:" : "Pracownik Banku:";
                    lbxMessagesContent.Items.Add(
                        $"{whoSend}\n" +
                        $"{message.Date}\n" +
                        $"{message.Message}"
                        );
                }
            }
            lbxMessagesContent.SelectedIndex = lbxMessagesContent.Items.Count - 1;
            lbxMessagesContent.ScrollIntoView(lbxMessagesContent.SelectedItem);
        }

        private void lbxClients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ReloadChat();
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            var content = tbxSendMessage.Text;

            using(var db = new DbBankContext())
            {
                var message = new InternalMessage()
                {
                    ClientId = selectedClient.Id,
                    EmployeeId = Session.ValidatedUser.Id,
                    Message = content,
                    ClientSend = false,
                    Date = DateTime.Now
                };
                db.InternalMessages.Add(message);
                db.SaveChanges();
            }

            ReloadChat();
            tbxSendMessage.Clear();
        }
    }
}
