using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Personal_Assistant.Model
{
    public class LightBulbItem : SmartHomeItem , INotifyPropertyChanged
    {
        
        public LightBulbItem(string name,string status)
        {
            timerEnabled = false;
            Id = Guid.NewGuid();
            Description = name;
            Status = status;
            
            if (status == "Online")
            {

                ImagePath = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_on.png" +
                                    "", UriKind.Relative)).ToString();
            }
            else if(status =="Offline")
            {
                ImagePath = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_off.png" +
                                    "", UriKind.Relative)).ToString();
            }
            
            
        }
    }
}
