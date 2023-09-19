using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace Personal_Assistant.Model
{
    public class TemperatureItem : SmartHomeItem, INotifyPropertyChanged
    {
        private double temperature;
        public double Temperature { get { return temperature; } set {
                temperature = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Temperature"));
            } }
        public TemperatureItem(string name, string status)
        {
           

            scheduleEnabled = false;
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
