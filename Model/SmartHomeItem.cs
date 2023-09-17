using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Xml.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Personal_Assistant.Model
{
    public class SmartHomeItem : INotifyPropertyChanged
    {

        private int timerMinutes, timerSeconds;
        public bool timerEnabled;

        public DateTime TimerTargetTime { get; set; } 
        public int TimerMinutes { get { return timerMinutes; } set 
            {
                timerMinutes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimerMinutes"));
            } }

        public int TimerSeconds
        {
            get { return timerSeconds; }
            set
            {
                timerSeconds = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimerSeconds"));
            }
        }


        public Guid Id { get; set; }    
        public string Description { get; set; }
        public string Status { get; set; } //offline or online
        private string imagePath;
        public string ImagePath { get { return imagePath; } 
            set {
            imagePath = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ImagePath"));
            } 
        }

        public SmartHomeItem()
        {
       
        }

        public SmartHomeItem(string _description,string _status)
        {
            Id = Guid.NewGuid();
            Description = _description;
            Status = _status;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
