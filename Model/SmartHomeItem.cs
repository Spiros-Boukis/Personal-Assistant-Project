using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Personal_Assistant.Model
{
    public class SmartHomeItem 
    {
        public Guid Id { get; set; }    
        public string Description { get; set; }
        public string Status { get; set; } //offline or online
       
        public string ImagePath { get; set; }

        public SmartHomeItem()
        {
       
        }

        public SmartHomeItem(string _description,string _status)
        {
            Id = Guid.NewGuid();
            Description = _description;
            Status = _status;
        }
    }
}
