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

namespace PokerXestWPF.Views
{
    public partial class CreateTournamentView : Window
    {
        public CreateTournamentView()
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

            var tournament = new TournamentModel()
            {
                Name = tournamentName.Text,
                Date = DateTime.Parse(tournamentDate.Text),
            };

            var tournamentRep = new TournamentRepository();
           
        }
    }
}
