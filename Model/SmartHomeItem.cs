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
        public DateTime ScheduleTime { get; set; }
        public DateTime ScheduleTargetTime { get; set; }
        private bool isOn;

        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                PropertyChangedMethod(this, "IsOn");
            }
        }
        private bool bulbSwitchIsEnabled;
        public bool BulbSwitchIsEnabled { get { return !ScheduleEnabled; } set { bulbSwitchIsEnabled = value;
                PropertyChangedMethod(this, "BulbSwitchIsEnabled");
            } }

        private bool scheduleEnabled;
        public bool ScheduleEnabled
        {
            get { return scheduleEnabled; }
            set { scheduleEnabled = value;
                BulbSwitchIsEnabled = !value;
                PropertyChangedMethod(this, "ScheduleEnabled");
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

        private DateTime timerTargetTime;
        public DateTime TimerTargetTime { get { return timerTargetTime; } set { timerTargetTime = value;
                PropertyChangedMethod(this, "TimerTargetTime");
            } } 
      

   


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
            TimerTargetTime = DateTime.Now;
            ScheduleEnabled = false;

        }

        public SmartHomeItem(string _description,string _status)
        {
            ScheduleEnabled = false;
            TimerTargetTime = DateTime.Now;
            Id = Guid.NewGuid();
            Description = _description;
            Status = _status;
            
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void PropertyChangedMethod(object? sender,string propertyName)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(propertyName));
        }
    }
}
