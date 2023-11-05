using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            //Displaya länder i combobox
            comboBox.ItemsSource = Enum.GetValues(typeof(Country));
            comboBox.SelectedIndex = 0;
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            //Kolla om textrutorna har fyllts i, om användarnamn är upptaget kollas i AddUser()-metoden genom valideringsmetoden.
            string username = rgstrUsername.Text;
            string password = rgstrPassword.Password;
            Country country = (Country)comboBox.SelectedItem;
            bool addUser = UserManager.AddUser(username, password, country);
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill out all the information", "Warning!");
                addUser = false;
            }
            else if (addUser)
            {
                MessageBox.Show("You are now a part of the TravelPal-community!" + Environment.NewLine + "Press 'OK' or 'Enter' to sign in!", "Welcome new user!");
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            //Återvänder till föregående fönster
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}
