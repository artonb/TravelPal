using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    public partial class TravelsWindow : Window
    {
        UserManager userManager;
        User user;
        public TravelsWindow()
        {
            InitializeComponent();
            //Lägger till det inloggade namnet i en label.
            lblUsername.Content = $"Welcome {UserManager.signedInUser.Username}";

            //Om admin loggar in så ska vissa knappar inte synas.
            if (UserManager.signedInUser.GetType() == typeof(Admin))
            {
                btnAdd.Visibility = Visibility.Hidden;
                howTo.Visibility = Visibility.Hidden;
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible;
                howTo.Visibility = Visibility.Visible;
            }
            //Om admin loggar in ska alla resor visas.
            if (UserManager.signedInUser.GetType() == typeof(Admin))
            {
                Admin admin = (Admin)UserManager.signedInUser;
                List<Travel> allTravels = new();
                allTravels = UserManager.GetAllUserTravels();

                foreach (var travel in allTravels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = travel;
                    item.Content = travel.Countries;
                    lstView.Items.Add(item);
                }
            }
            //Om en User loggar in ska endast dens egna resor synas
            if (UserManager.signedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.signedInUser;
                List<Travel> existingTravels = new();
                existingTravels = user.Travels;
                foreach (Travel travel in existingTravels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = travel;
                    item.Content = travel.Countries;
                    lstView.Items.Add(item);
                }
            }
        }
        //Visa en MessageBox där det framgår vad appen är till för
        private void howTo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This app is made by TravelPal and developed by Arton Brahimi." + Environment.NewLine + Environment.NewLine + "Here you can add your travel details to your travels. We will save this for you so you have an easier and better experience on your trip! ", "How to use the app TravelPal");
        }
        //Loggar ut och går till föregående fönster.
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
        //Ta bort resan och visa felmeddelande om man inte väljer en resa
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            ListViewItem selectedItem = (ListViewItem)lstView.SelectedItem;

            if (selectedItem != null)
            {
                Travel travelToRemove = (Travel)selectedItem.Tag;

                if (UserManager.signedInUser is User)
                {
                    ((User)UserManager.signedInUser).Travels.Remove(travelToRemove);
                }
                else if (UserManager.signedInUser is Admin)
                {
                    UserManager.AdminRemoveTravel(travelToRemove);
                }

                lstView.Items.Remove(selectedItem);
            }
            else
            {
                MessageBox.Show("You need to select the item you want to remove!", "Item not selected!");
            }
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        //Går till AddTravel-fönster
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravel = new AddTravelWindow(userManager);
            addTravel.Show();
            Close();
        }
        //Går till detailsWindow och visar detaljer på resan, om inte en resa väljs ska ett varningsmeddelande visas
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstView.SelectedItem;
            if (selectedItem != null)
            {
                Travel selectedTravel = (Travel)selectedItem.Tag;
                TravelDetailsWindow travelDetailWindow = new(selectedTravel);
                travelDetailWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You need to select the item you want more details on!", "Item not selected!");
            }
        }

        //Går tillbaka till föregående fönster
        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
