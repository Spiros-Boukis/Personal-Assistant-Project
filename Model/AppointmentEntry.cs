using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Controls;

namespace Personal_Assistant.Model
{
    public class AppointmentEntry : INotifyPropertyChanged

    {
        public Guid Id { get; set; }

        private string title;
        public string Title { 
            get { return title; } 
            set { title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }
        private string description;
        public string Description
        {
            get { return description ; }
            set
            {
                description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public int Type; // 0 = normal , 1 = important , 2 = Deadline

        public event PropertyChangedEventHandler? PropertyChanged;
        private DateTime? time;
        public DateTime? Time
        {
            get { return time; }
            set
            {
                time = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Time"));
            }
        }

        public AppointmentEntry()
        {
                
        }
        public AppointmentEntry(string _title,string description, int type,DateTime? time)
        {
            Title = _title;
            Description = description;
            Type = type;
            Id = Guid.NewGuid();
            Time = time;
        }
    }
}
