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
                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please add all information!");
            }

        }
    }
}
