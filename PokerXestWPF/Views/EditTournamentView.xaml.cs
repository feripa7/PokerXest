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
    public partial class EditTournamentView : Window
    {
        public EditTournamentView()
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

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        { 
           var tournamentRep = new TournamentRepository();
            try
            {
                tournamentRep.Remove(Convert.ToInt32(tournamentIdEdit.Text));
                System.Windows.MessageBox.Show("Torneo eliminado correctamente");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            var tournament = new TournamentModel()
            {
                Name = tournamentNameEdit.Text,
                Date = DateTime.Parse(tournamentDateEdit.Text),
                Time = DateTime.Parse(tournamentHourEdit.Text),
                Comision = Convert.ToDouble(tournamentComisionEdit.Text),
                MinLevel = Convert.ToInt32(tournamentMinLvlEdit.Text),
                Price = Convert.ToDouble(tournamentPriceEdit.Text)
            };

            var tournamentRep = new TournamentRepository();
            try
            {
                tournamentRep.Edit(tournament);
                System.Windows.MessageBox.Show("Torneo modificado correctamente");

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }
    }
}
