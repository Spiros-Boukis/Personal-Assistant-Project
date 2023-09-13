using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Resources;

namespace Personal_Assistant.Model
{
    public class SmartHomeItem 
    {
        public int Type { get; set; } // 1 = lightbulb , 2 = Temperature , 
        public string Description { get; set; }
        public string Status { get; set; } //offline or online

        public SmartHomeItem()
        {
                
        }

        public SmartHomeItem(int type,string _description,string _status)
        {
            Type = type;
            Description = _description;
            Status = _status;
        }
    }
}
