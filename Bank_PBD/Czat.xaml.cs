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
                    ClientId = Session.ValidatedClient.Id,
                    ClientSend = true,
                    Date = DateTime.Now                    
                };
                db.InternalMessages.Add(message);
                db.SaveChanges();
                ReloadChat();
            }
        }
        private void ReloadChat()
        {
            using (var db = new DbBankContext())
            {
                var messages = db.InternalMessages
                    .Where(m => m.ClientId == Session.ValidatedClient.Id)
                    .Select(m => m)
                    .OrderBy(m => m.Date);

                foreach (var message in messages)
                {
                    var whoSend = (message.ClientSend) ? "Ty" : "Pracownik Banku";
                    lbxChatContent.Items.Add(
                        $"{whoSend}\n" +
                        $"{message.Date}\n" +
                        $"{message.Message}"
                        );
                }
            }
        }
    }
}
