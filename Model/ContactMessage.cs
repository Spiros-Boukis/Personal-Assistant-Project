using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Assistant.Model
{
    public class ContactMessage
    {
        public enum MessageType : int { Incoming = 0, Outgoing = 1  }
        public int Type { get; set; }
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public Contact Sender { get; set; }

        public ContactMessage()
        {
                
        }

        public ContactMessage(int type,string message, Contact sender)
        {
            Type = type;
            Message = message;
            Sender = sender;
            Date = DateTime.Now;

        }

        public ContactMessage(int type, string message, Contact sender,DateTime _date)
        {
            Type = type;
            Message = message;
            Sender = sender;
            Date = _date;

        }
    }
}
