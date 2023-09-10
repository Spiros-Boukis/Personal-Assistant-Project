using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Assistant.Model
{
    public class AppointmentEntry
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Type; // 0 = normal , 1 = important , 2 = Deadline


        public AppointmentEntry()
        {
                
        }
        public AppointmentEntry(string _title,string description, int type)
        {
            Title = _title;
            Description = description;
            Type = type;
            Id = Guid.NewGuid();
        }
    }
}
