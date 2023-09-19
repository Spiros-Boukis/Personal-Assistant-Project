using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
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
        public bool TimerEnabled
        {
            get { return timerEnabled; }
            set { timerEnabled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TimerEnabled"));
                }
        }
        public bool itemStatus;

        public bool ItemStatus {
            get
            {
                if (Status == "Online")
                    return true;
                else if (Status == "Offline")
                    return false;
                return true;
            }
            set
            {
                itemStatus = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemStatus"));
            }
}
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
                if (timerSeconds == 0)
                {

                    if (timerMinutes == 0)
                    {
                        timerSeconds = 0;
                    }
                    else
                    {
                        TimerMinutes--;
                        timerSeconds = 59;
                    }

                }
                else if (value > 0)
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
            TimerSeconds = 0;
            TimerMinutes = 1;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChangedMethod(object? sender,string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
