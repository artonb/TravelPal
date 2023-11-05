using System.Windows;
using System.Windows.Controls;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow(Travel selectedTravel)
        {
            InitializeComponent();

            //Visar detaljer på resorna genom GetInfo()-metoderna i respektive restyp.
            ListViewItem item = new();
            item.Tag = selectedTravel;
            item.Content = selectedTravel.GetInfo();
            lstView.Items.Add(item);
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            //Går till föregående fönster
            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }

        private void lstView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
