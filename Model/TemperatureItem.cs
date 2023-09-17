using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Personal_Assistant.Model
{
    public class TemperatureItem : SmartHomeItem
    {

        public double Temperature { get; set; }
        public TemperatureItem(string name, string status)
        {

            Id = Guid.NewGuid();

            Description = name;
            Status = status;

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
