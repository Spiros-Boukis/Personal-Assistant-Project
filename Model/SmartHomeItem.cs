using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Assistant.Model
{
    public class SmartHomeItem 
    {
        public int Type { get; set; } // 1 = lightbulb , 2 = Temperature , 

        public SmartHomeItem()
        {
                
        }

        public SmartHomeItem(int type)
        {
                Type = type;
        }
    }
}
