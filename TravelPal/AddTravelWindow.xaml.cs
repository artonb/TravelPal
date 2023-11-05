using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Interface;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow(UserManager users)
        {
            InitializeComponent();
            //Displaya länder och resetyp i comboboxar
            boxCountry.ItemsSource = Enum.GetValues(typeof(Country));
            txtTravellers.Text = "0";
            boxCountry.SelectedIndex = 0;
            boxType.Items.Add("Vacation");
            boxType.Items.Add("Work trip");
            boxType.SelectedIndex = 0;
        }
        private void boxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //Visa endast allInclusive om vacation väljs och vice verca med workTrip.
            if (boxType.SelectedIndex == 0)
            {
                hdnMeeting.Visibility = Visibility.Hidden;
                hdnMeeting1.Visibility = Visibility.Hidden;
                hdnAll.Visibility = Visibility.Visible;
            }
            else
            {
                hdnAll.Visibility = Visibility.Hidden;
                hdnMeeting.Visibility = Visibility.Visible;
                hdnMeeting1.Visibility = Visibility.Visible;
            }
        }

        public void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Skippa metoder i TravelManager, använd UserManager istället
            string meetingDetails = hdnMeeting1.Text;
            string destination = txtCity.Text;
            Country countries = (Country)boxCountry.SelectedItem;
            int travellers = Convert.ToInt32(txtTravellers.Text);
            string trip = (string)boxType.SelectedItem;
            IUser u = UserManager.signedInUser;
            User signedInUser = (User)u;
            if (string.IsNullOrEmpty(destination))
            {
                MessageBox.Show("Please input all the boxes", "Warning!");
                return;
            }
            else if (trip == "Work trip")
            {
                WorkTrip worktrip = new WorkTrip(meetingDetails, destination, countries, travellers);
                signedInUser.Travels.Add(worktrip);
            }
            else if (trip == "Vacation")
            {
                Vacation vacation = new Vacation(destination, countries, travellers, (bool)hdnAll.IsChecked);
                signedInUser.Travels.Add(vacation);
            }

            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            //Återvänd till föregående fönster
            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }
    }
}
