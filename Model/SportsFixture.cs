using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Assistant.Model
{
    public class SportsFixture
    {
        private string team1, team2,place,time;

        public string Team1 { get { return team1; } set { team1 = value; } }

        public string Team2 { get { return team2; } set { team2 = value; } }

        public string Place { get { return place; } set { place = place; } }

        public string Time { get { return time; } set { time = place; } }

        public SportsFixture(string _team1,string _team2,string _time,string _place)
        {
            team1 = _team1;
            team2 = _team2;
            place = _place;
            time = _time;
        }
    }
}
