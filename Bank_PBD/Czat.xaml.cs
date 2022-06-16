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
using Bank_PBD.Model;
using Bank_PBD.Storage;

namespace Bank_PBD
{
    public partial class Czat : Window
    {
        public Czat()
        {
            InitializeComponent();
            ReloadChat();            
        }
        private void SendMessage(string msg)
        {
            using(var db = new DbBankContext())
            {
                var message = new InternalMessage()
                {
                    Message = msg,
                    ClientId = Session.ValidatedUser.Id,
                    ClientSend = true,
                    Date = DateTime.Now,
                    EmployeeId = null
                };

                db.InternalMessages.Add(message);
                db.SaveChanges();
                ReloadChat();
            }
        }
        private void ReloadChat()
        {
            lbxChatContent.Items.Clear();
            using (var db = new DbBankContext())
            {
                var messages = db.InternalMessages
                    .Where(m => m.ClientId == Session.ValidatedUser.Id)
                    .Select(m => m)
                    .OrderBy(m => m.Date);

                foreach (var message in messages)
                {
                    var whoSend = (message.ClientSend) ? "Ty:" : "Pracownik Banku:";
                    lbxChatContent.Items.Add(
                        $"{whoSend}\n" +
                        $"{message.Date}\n" +
                        $"{message.Message}"
                        );
                }
            }
            lbxChatContent.SelectedIndex = lbxChatContent.Items.Count - 1;
            lbxChatContent.ScrollIntoView(lbxChatContent.SelectedItem);
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            SendMessage(tbxMessageContent.Text);
            tbxMessageContent.Clear();
        }
    }
}
