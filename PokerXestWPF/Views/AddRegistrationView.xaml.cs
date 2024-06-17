using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Resources.ResXFileRef;

namespace PokerXestWPF.Views
{
    /// <summary>
    /// Lógica de interacción para RegistrationForm.xaml
    /// </summary>
    public partial class AddRegistrationView : Window
    {
        public AddRegistrationView()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            var registration = new RegistrationModel()
            {
                PlayerDni = dniPlayerRegistration.Text,
                TournamentID = Convert.ToInt32(tournamentId.Text),
                TournamentDate = DateTime.Now,
            };

            var registrationRep = new RegistrationRepository();
            try
            {
                registrationRep.Add(registration);
                System.Windows.MessageBox.Show("Rexistro completado");

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }
    }
}
