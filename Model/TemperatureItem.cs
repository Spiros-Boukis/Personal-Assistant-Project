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
    public class TemperatureItem : SmartHomeItem
    {
        public int ScheduleType {  get; set; } // 0 : increase , 1 :descreasevvvv
        public int TargetTemperature {  get; set; } 
        private double temperature;
        private string setTemperature;
        public double Temperature { get { return temperature; } set {
                temperature = value;
                PropertyChangedMethod(this, "Temperature");
            } }

        public string SetTemperature
        {
            get { return setTemperature; }
            set
            {
                setTemperature = value;
                PropertyChangedMethod(this, "SetTemperature");
            }
        }



        public TemperatureItem(string name, string status)
        {
            SetTemperature = "20";

            ScheduleEnabled = false;
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
            
           
        }

       
    }
}
