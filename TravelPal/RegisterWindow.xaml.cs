using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();

            comboBox.ItemsSource = Enum.GetValues(typeof(Country));
            comboBox.SelectedIndex = 0;

            //foreach (Country country in Enum.GetValues(typeof(Country)))
            //{
            //    ListViewItem item = new();
            //    item.Content = country.ToString();
            //    item.Tag = country;
            //    comboBox.Items.Add(item);
            //}
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = rgstrUsername.Text;
            string password = rgstrPassword.Password;
            Country country = (Country)comboBox.SelectedItem;
            bool addUser = UserManager.AddUser(username, password, country);
            if (addUser)
            {
                MessageBox.Show("You are now a part of the TravelPal-community!" + Environment.NewLine + "Press 'OK' or 'Enter' to sign in!", "Welcome new user!");
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
            else
            {
                addUser = false;
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
