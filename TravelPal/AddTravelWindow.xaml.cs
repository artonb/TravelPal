using System;
using System.Windows;
using TravelPal.Enums;

namespace TravelPal
{
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();
            boxCountry.ItemsSource = Enum.GetValues(typeof(Country));
            boxCountry.SelectedIndex = 0;
            boxType.Items.Add("--- Purpose of trip ---");
            boxType.Items.Add("Vacation");
            boxType.Items.Add("Work trip");
            boxType.SelectedIndex = 0;



        }

        private void boxType_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (boxType.SelectedIndex == 1)
            {
                hdnMeeting.Visibility = Visibility.Hidden;
                hdnMeeting1.Visibility = Visibility.Hidden;
                hdnAll.Visibility = Visibility.Visible;
            }
            else if (boxType.SelectedIndex == 2)
            {
                hdnAll.Visibility = Visibility.Hidden;
                hdnMeeting.Visibility = Visibility.Visible;
                hdnMeeting1.Visibility = Visibility.Visible;
            }
            else
            {
                hdnAll.Visibility = Visibility.Hidden;
                hdnMeeting.Visibility = Visibility.Hidden;
                hdnMeeting1.Visibility = Visibility.Hidden;
            }
        }
    }
}
