using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace PokerXestWPF.Views
{
    public partial class DealerRegistrationView : Window
    {
        public DealerRegistrationView()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void backBtn_Click(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            var dealerWorkloadModel = new DealerWorkloadModel()
            {
                DealerDni = dniDealerRegistration.Text,
                TournamentID = Convert.ToInt32(tournamentId.Text),
                TournamentDate = DateTime.Now,
            };

            var dealerWorkloadRep = new DealerWorkloadRepository();
            
        }
    }
}
