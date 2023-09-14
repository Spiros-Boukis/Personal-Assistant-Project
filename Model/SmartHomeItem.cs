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

        public int Type { get; set; } // 1 = lightbulb , 2 = Temperature , 
        public string Description { get; set; }
        public string Status { get; set; } //offline or online

        public double Temperature { get; set; }

        public string ImagePath { get; set; }

        public SmartHomeItem()
        {
            
        }

        public SmartHomeItem(int type,string _description,string _status)
        {
            Id = Guid.NewGuid();
            Type = type;
            Description = _description;
            Status = _status;
            Temperature = (double)RandomNumberGenerator.GetInt32(19, 30);
            double newTemp = 0; ;
            var random = (double)RandomNumberGenerator.GetInt32(0, 100);
            random = random * 0.01;
            var choice = RandomNumberGenerator.GetInt32(1, 2);
            if (choice == 1)
            {
                Temperature = Temperature + random;
                Temperature = Math.Round(Temperature, 2);
            }
            if (choice == 2)
            {
                Temperature = Temperature - random;
                Temperature = Math.Round(Temperature, 2);
            }
            ImagePath = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_on.png" +
                                "", UriKind.Relative)).ToString();
        }
    }
}
