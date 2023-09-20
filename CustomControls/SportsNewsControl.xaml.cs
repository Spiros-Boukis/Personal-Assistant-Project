﻿using ModernWpf.Controls;
using Notifications.Wpf.Annotations;
using Personal_Assistant.Model;
using Personal_Assistant.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using Xceed.Wpf.AvalonDock.Controls;
using ListViewItem = System.Windows.Controls.ListViewItem;

namespace Personal_Assistant.CustomControls
{

    public class DaySportsFixtures
    {
        public string Date { get; set; }
        public List<SportsFixture> Fixtures { get; set; }

        public DaySportsFixtures()
        {
                
        }

        public DaySportsFixtures(string date, List<SportsFixture> fixtures)
        {
            this.Date = date;
            this.Fixtures = fixtures;
        }
    }
    /// <summary>
    /// Interaction logic for SportsNewsControl.xaml
    /// </summary>
    public partial class SportsNewsControl : UserControl
    {
        public List<SportsFixture> footballFixturesDay1 = new List<SportsFixture>();
        public List<SportsFixture> basketballFixtures = new List<SportsFixture>();
        public List<SportsFixture> tennisFixtures = new List<SportsFixture>();
        public CalendarTab container;
        public List<DaySportsFixtures> basketballOflists { get; set; }
        public List<DaySportsFixtures> footballLists { get; set; }
        public List<DaySportsFixtures> tennisLists { get; set; }

        public void FeedSportsFixtures()
        {
            footballLists = new List<DaySportsFixtures>();
            //Football
            List<SportsFixture> FixturesDay1 = new List<SportsFixture>();
            FixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium",0));
            FixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 0));
            FixturesDay1.Add(new SportsFixture("Real", "Barca", "19:00", "OAKA", 0));
            FixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            var currentDay = DateTime.Now;
            string formattedDay = currentDay.ToString("dd/MM/yyyy");
      
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay1));
            currentDay = currentDay.AddDays(1);
            

            List<SportsFixture> FixturesDay2 = new List<SportsFixture>();
            FixturesDay2.Add(new SportsFixture("Man City", "Arsenjal", "19:00", "OAKA Stadium", 0));
            FixturesDay2.Add(new SportsFixture("QPR", "MU", "21:00", "Volos Stadium", 0));
            FixturesDay2.Add(new SportsFixture("Chelsea", "Liverpool", "19:00", "", 0));
            FixturesDay2.Add(new SportsFixture("Dortmund", "Herta", "19:00", "OAKA Stadium", 0));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay2));
            currentDay = currentDay.AddDays(1);

            List<SportsFixture> FixturesDay3 = new List<SportsFixture>();
            FixturesDay3.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            FixturesDay3.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 0));
            FixturesDay3.Add(new SportsFixture("q", "w", "19:00", "", 0));
            FixturesDay3.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay3));
            currentDay = currentDay.AddDays(1);

            List<SportsFixture> FixturesDay4 = new List<SportsFixture>();
            FixturesDay4.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            FixturesDay4.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 0));
            FixturesDay4.Add(new SportsFixture("q", "w", "19:00", ""));
            FixturesDay4.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay4));
            currentDay = currentDay.AddDays(1);

            List<SportsFixture> FixturesDay5 = new List<SportsFixture>();
            FixturesDay5.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            FixturesDay5.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 0));
            FixturesDay5.Add(new SportsFixture("q", "w", "19:00", "", 0));
            FixturesDay5.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay5));
            currentDay = currentDay.AddDays(1);

            List<SportsFixture> FixturesDay6 = new List<SportsFixture>();
            FixturesDay6.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            FixturesDay6.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 0));
            FixturesDay6.Add(new SportsFixture("q", "w", "19:00", "", 0));
            FixturesDay6.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay6));
            currentDay = currentDay.AddDays(1);

            List<SportsFixture> FixturesDay7 = new List<SportsFixture>();
            FixturesDay7.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            FixturesDay7.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 0));
            FixturesDay7.Add(new SportsFixture("q", "w", "19:00", "", 0));
            FixturesDay7.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 0));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            footballLists.Add(new DaySportsFixtures(formattedDay, FixturesDay7));
            currentDay = currentDay.AddDays(1);



            basketballOflists = new List<DaySportsFixtures>();
            //basket
             FixturesDay1 = new List<SportsFixture>();
            FixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            FixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 1));
            FixturesDay1.Add(new SportsFixture("Real", "Barca", "19:00", "OAKA", 1));
            FixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
             currentDay = DateTime.Now;
             formattedDay = currentDay.ToString("dd/MM/yyyy");

            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay1));
            currentDay = currentDay.AddDays(1);


             FixturesDay2 = new List<SportsFixture>();
            FixturesDay2.Add(new SportsFixture("Man City", "Arsenjal", "19:00", "OAKA Stadium", 1));
            FixturesDay2.Add(new SportsFixture("QPR", "MU", "21:00", "Volos Stadium", 1));
            FixturesDay2.Add(new SportsFixture("Chelsea", "Liverpool", "19:00", "", 1));
            FixturesDay2.Add(new SportsFixture("Dortmund", "Herta", "19:00", "OAKA Stadium", 1));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay2));
            currentDay = currentDay.AddDays(1);

            FixturesDay3 = new List<SportsFixture>();
            FixturesDay3.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            FixturesDay3.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 1));
            FixturesDay3.Add(new SportsFixture("q", "w", "19:00", "", 1));
            FixturesDay3.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay3));
            currentDay = currentDay.AddDays(1);

             FixturesDay4 = new List<SportsFixture>();
            FixturesDay4.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            FixturesDay4.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 1));
            FixturesDay4.Add(new SportsFixture("q", "w", "19:00", "",1));
            FixturesDay4.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay4));
            currentDay = currentDay.AddDays(1);

           FixturesDay5 = new List<SportsFixture>();
            FixturesDay5.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            FixturesDay5.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 1));
            FixturesDay5.Add(new SportsFixture("q", "w", "19:00", "", 1));
            FixturesDay5.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay5));
            currentDay = currentDay.AddDays(1);

            FixturesDay6 = new List<SportsFixture>();
            FixturesDay6.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            FixturesDay6.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 1));
            FixturesDay6.Add(new SportsFixture("q", "w", "19:00", "", 1));
            FixturesDay6.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay6));
            currentDay = currentDay.AddDays(1);

             FixturesDay7 = new List<SportsFixture>();
            FixturesDay7.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            FixturesDay7.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 1));
            FixturesDay7.Add(new SportsFixture("q", "w", "19:00", "", 1));
            FixturesDay7.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 1));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            basketballOflists.Add(new DaySportsFixtures(formattedDay, FixturesDay7));
            currentDay = currentDay.AddDays(1);


            tennisLists = new List<DaySportsFixtures>();
            //tennis
            FixturesDay1 = new List<SportsFixture>();
            FixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            FixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 2));
            FixturesDay1.Add(new SportsFixture("Real", "Barca", "19:00", "OAKA", 2));
            FixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            currentDay = DateTime.Now;
            formattedDay = currentDay.ToString("dd/MM/yyyy");

            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay1));
            currentDay = currentDay.AddDays(1);


            FixturesDay2 = new List<SportsFixture>();
            FixturesDay2.Add(new SportsFixture("Man City", "Arsenjal", "19:00", "OAKA Stadium", 2));
            FixturesDay2.Add(new SportsFixture("QPR", "MU", "21:00", "Volos Stadium", 2));
            FixturesDay2.Add(new SportsFixture("Chelsea", "Liverpool", "19:00", "", 2));
            FixturesDay2.Add(new SportsFixture("Dortmund", "Herta", "19:00", "OAKA Stadium", 2));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay2));
            currentDay = currentDay.AddDays(1);

            FixturesDay3 = new List<SportsFixture>();
            FixturesDay3.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            FixturesDay3.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 2));
            FixturesDay3.Add(new SportsFixture("q", "w", "19:00", "", 2));
            FixturesDay3.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay3));
            currentDay = currentDay.AddDays(1);

            FixturesDay4 = new List<SportsFixture>();
            FixturesDay4.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            FixturesDay4.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 2));
            FixturesDay4.Add(new SportsFixture("q", "w", "19:00", "", 2));
            FixturesDay4.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay4));
            currentDay = currentDay.AddDays(1);

            FixturesDay5 = new List<SportsFixture>();
            FixturesDay5.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            FixturesDay5.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 2));
            FixturesDay5.Add(new SportsFixture("q", "w", "19:00", "", 2));
            FixturesDay5.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay5));
            currentDay = currentDay.AddDays(1);

            FixturesDay6 = new List<SportsFixture>();
            FixturesDay6.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            FixturesDay6.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 2));
            FixturesDay6.Add(new SportsFixture("q", "w", "19:00", "", 2));
            FixturesDay6.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay6));
            currentDay = currentDay.AddDays(1);

            FixturesDay7 = new List<SportsFixture>();
            FixturesDay7.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            FixturesDay7.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium", 2));
            FixturesDay7.Add(new SportsFixture("q", "w", "19:00", "", 2));
            FixturesDay7.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium", 2));
            formattedDay = formattedDay = currentDay.ToString("dd/MM/yyyy");
            tennisLists.Add(new DaySportsFixtures(formattedDay, FixturesDay7));
            currentDay = currentDay.AddDays(1);


        }
        public SportsNewsControl()
        {

            InitializeComponent();

            FeedSportsFixtures();



            /*  footballFixturesDay1.Add(new SportsFixture("OSFP","PAO","19:00","OAKA Stadium"));
              footballFixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              footballFixturesDay1.Add(new SportsFixture("q", "w", "19:00", ""));
              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));

              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              footballFixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              footballFixturesDay1.Add(new SportsFixture("q", "w", "19:00", ""));
              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));

              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              footballFixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              footballFixturesDay1.Add(new SportsFixture("q", "w", "19:00", ""));
              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));

              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              footballFixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              footballFixturesDay1.Add(new SportsFixture("q", "w", "19:00", ""));
              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));

              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              footballFixturesDay1.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              footballFixturesDay1.Add(new SportsFixture("q", "w", "19:00", ""));
              footballFixturesDay1.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));

              basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              basketballFixtures.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              basketballFixtures.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              basketballFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              basketballFixtures.Add(new SportsFixture("qwer", "Aek", "21:00", "Volos Stadium"));

              tennisFixtures.Add(new SportsFixture("Real Madrid", "Barcelona", "19:00", "Estadio Santiago Bernabeu"));
              tennisFixtures.Add(new SportsFixture("Volos", "Aek", "21:00", "Volos Stadium"));
              tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
              tennisFixtures.Add(new SportsFixture("OSFP", "PAO", "19:00", "OAKA Stadium"));
            */
            //footballFixturesListView.ItemsSource = sportsFixtures;
            //footballFixturesListView.ItemsSource = basketballFixtures;
            //tennisFixturesListView.ItemsSource = tennisFixtures;






            testItemsControl.ItemsSource = footballLists;
            basketballItemsControl.ItemsSource = basketballOflists;
                tennisItemsControl.ItemsSource = tennisLists;



        }

        private ListViewItem FindButtonListViewContainer(Button sender,ItemsControl _list)
        {
            var lists = _list.FindVisualChildren<System.Windows.Controls.ListViewItem>();

            foreach (var list in lists)
            {
                var children = list.FindVisualChildren<Button>();
                foreach (var button in children)
                {
                    if (button == sender)
                    {
                        return list;
                    }
                }
            }
            return null;
        }

        private ContentPresenter FindButtonListViewContainer1(Button sender, ItemsControl _list)
        {
            var lists = _list.FindVisualChildren<ContentPresenter>();
            var testList = new List<ContentPresenter>();
            foreach (var list in lists)
            {
                var children = list.FindVisualChildren<Button>();
                foreach (var button in children)
                {
                    if (button == sender)
                    {
                       testList.Add(list);

                        var conte = list.Content;
                    }
                }
            }
            return null;
        }

        private T FindButtonListViewContainerGeneric<T>(Button sender, ItemsControl _list)
        {
            var lists = _list.FindVisualChildren<ContentPresenter>();
            var testList = new List<ContentPresenter>();
            foreach (var list in lists)
            {
                var children = list.FindVisualChildren<Button>();
                foreach (var button in children)
                {
                    if (button == sender)
                    {
                        if(list.Content!=null)
                        {
                            if (list.Content.GetType() == typeof(T))
                            {
                               T _temp = (T)list.Content;
                                return _temp;
                            }
                            
                        }
                        

                        var conte = list.Content;
                    }
                }
            }
            return default(T);
        }

        private void Notify_Football(object sender, RoutedEventArgs e)
        {
            

            var fixture = FindButtonListViewContainerGeneric<SportsFixture>((Button)sender,testItemsControl);
            if(fixture==null)
                fixture = FindButtonListViewContainerGeneric<SportsFixture>((Button)sender, basketballItemsControl);
            if(fixture==null)
                fixture = FindButtonListViewContainerGeneric<SportsFixture>((Button)sender, tennisItemsControl);


            DaySportsFixtures test = FindButtonListViewContainerGeneric<DaySportsFixtures>((Button)sender,testItemsControl) as DaySportsFixtures;
            if (test == null)
                test = FindButtonListViewContainerGeneric<DaySportsFixtures>((Button)sender, basketballItemsControl) as DaySportsFixtures;
            if (test == null)
                 test = FindButtonListViewContainerGeneric<DaySportsFixtures>((Button)sender, tennisItemsControl) as DaySportsFixtures;

            string notifyText = fixture.Team1 + " v. " + fixture.Team2;

            container.AddedSportsFixtureAppointment(notifyText, test.Date, fixture.Time,fixture.Type);

        }
       
    }
}
