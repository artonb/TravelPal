using System.Windows;
using System.Windows.Controls;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
            lblUsername.Content = $"Welcome {UserManager.signedInUser.Username}";

        }

        private void howTo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This app is made by TravelPal and developed by Arton Brahimi. Here you can add your travel details to your travels. We will save this for you so you have an easier and better experience on your trip! ", "How to use the app TravelPal");
        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxItem selectedItem = (ListViewItem)lstView.SelectedItem;
            //selectedItem.Items.Remove(selectedItem);
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
