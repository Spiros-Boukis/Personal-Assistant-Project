using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Assistant.Model
{
    public class Contact : INotifyPropertyChanged
    {
        private string name, phonenumber;
        public string Name { get { return name; } set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string PhoneNumber { get { return phonenumber; } set { 
                phonenumber = value; OnPropertyChanged();
            } }

        public Contact()
        {
            name = "'place name here'";
            phonenumber = "1234567890";
        }

        public Contact(string _name, string number)
        {
            name = _name;
            phonenumber = number;   
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
