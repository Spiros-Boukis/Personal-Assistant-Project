using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Assistant.Model
{
    public class EmailEntry
    {
        public string Identifier { get; set; }
        public string From {  get; set; }
        public string To { get; set; }  
        public string Title { get; set; }
        public string Body { get; set; }

        public EmailEntry()
        {

        }

        public EmailEntry(string from, string to, string title,string body)
        {
            From = from;
            To = to;
            Title = title;
            Body = body;
            Identifier = Guid.NewGuid().ToString();
        }
    }
}
