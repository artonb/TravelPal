using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        UserManager userManager;
        public TravelsWindow()
        {
            InitializeComponent();
            lblUsername.Content = $"Welcome {UserManager.signedInUser.Username}";
            if (UserManager.signedInUser.GetType() == typeof(Admin))
            {
                btnAdd.Visibility = Visibility.Hidden;
                btnRemove.Visibility = Visibility.Hidden;
                howTo.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible;
                btnRemove.Visibility = Visibility.Visible;
                howTo.Visibility = Visibility.Visible;
            }

            if (UserManager.signedInUser.GetType() == typeof(Admin))
            {
                Admin admin = (Admin)UserManager.signedInUser;
                List<Travel> allTravels = new();

            }

            if (UserManager.signedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.signedInUser;
                List<Travel> travels = new();
                travels = user.Travels;
                foreach (Travel travel in travels)
                {
                    ListViewItem item = new();
                    item.Tag = travel;
                    item.Content = travel.Countries;
                    lstView.Items.Add(item);
                }
            }
        }

        private void howTo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This app is made by TravelPal and developed by Arton Brahimi." + Environment.NewLine + Environment.NewLine + "Here you can add your travel details to your travels. We will save this for you so you have an easier and better experience on your trip! ", "How to use the app TravelPal");
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            ListViewItem selectedItem = (ListViewItem)lstView.SelectedItem;
            if (selectedItem != null)
            {
                Travel selectedTravel = (Travel)selectedItem.Tag;
                lstView.Items.Remove(selectedItem);
                ListViewItem itemToRemove = (ListViewItem)lstView.SelectedItem;
                lstView.Items.Remove(itemToRemove);

            }
            else
            {
                MessageBox.Show("You need to select the item you want to remove!", "Item not selected!");
            }
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //foreach (ListViewItem item in lstView.Items)
            //{
            //    ListBoxItem selectedItem = (ListViewItem)lstView.SelectedItem;

            //}
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravel = new AddTravelWindow(userManager);
            addTravel.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstView.SelectedItem;
            if (selectedItem != null)
            {
                Travel selectedTravel = (Travel)selectedItem.Tag;
                TravelDetailsWindow travelDetailWindow = new();
                travelDetailWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You need to select the item you want more details on!", "Item not selected!");
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
