using System.Windows;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            //Läs innehållet i username och password-textrutorna
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            //Använd UserManager för att testa logga in
            bool isSignedIn = UserManager.signInUser(username, password);

            //Om inloggningen lyckas, öppna TravelsWindow
            if (isSignedIn)
            {
                TravelsWindow travelswindow = new();
                travelswindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Warning!");
            }

            //Om inloggningen misslyckas, visa felmeddelande

        }
    }
}
