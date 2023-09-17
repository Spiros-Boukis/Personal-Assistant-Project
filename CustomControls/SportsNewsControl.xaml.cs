using Personal_Assistant.Model;
using Personal_Assistant.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Personal_Assistant.CustomControls
{
    /// <summary>
    /// Interaction logic for SportsNewsControl.xaml
    /// </summary>
    public partial class SportsNewsControl : UserControl
    {
        public List<SportsFixture> sportsFixtures = new List<SportsFixture>();
        public List<SportsFixture> basketballFixtures = new List<SportsFixture>();
        public List<SportsFixture> tennisFixtures = new List<SportsFixture>();
        public CalendarTab container;
        public SportsNewsControl()
        {
            InitializeComponent();

            sportsFixtures.Add(new SportsFixture("OSFP","PAO","19:00","OAKA Stadium"));
            sportsFixtures.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
            sportsFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
            sportsFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));


            basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
            basketballFixtures.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
            basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
            basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));

            tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
            tennisFixtures.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
            tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
            tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));



            footballFixturesListView.ItemsSource = sportsFixtures;
            basketballFixturesListView.ItemsSource = basketballFixtures;
            tennisFixturesListView.ItemsSource = tennisFixtures;

            
            
        }

        private void Notify_Football(object sender, RoutedEventArgs e)
        {
            SportsFixture selected = footballFixturesListView.SelectedItem as SportsFixture;
            string notifyText = selected.Team1 + " v. " + selected.Team2;

            container.AddedSportsFixtureAppointment(notifyText, selected.Time,0);

        }
        private void Notify_Basketball(object sender, RoutedEventArgs e)
        {
            SportsFixture selected = basketballFixturesListView.SelectedItem as SportsFixture;
            string notifyText = selected.Team1 + " v. " + selected.Team2;

            container.AddedSportsFixtureAppointment(notifyText, selected.Time, 1);

        }
        private void Notify_Tennis(object sender, RoutedEventArgs e)
        {
            SportsFixture selected = tennisFixturesListView.SelectedItem as SportsFixture;
            string notifyText = selected.Team1 + " v. " + selected.Team2;

            container.AddedSportsFixtureAppointment(notifyText, selected.Time, 2);

        }
    }
}
