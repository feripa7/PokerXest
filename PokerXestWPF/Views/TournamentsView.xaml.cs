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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerXestWPF.Views
{
    public partial class TournamentsView : UserControl
    {
        public TournamentsView()
        {
            InitializeComponent();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            EditTournamentView editTournamentView = new EditTournamentView();
            editTournamentView.Show();
        }

        private void createBtn_Click(Object sender, RoutedEventArgs e)
        {
            CreateTournamentView createTournamentView = new CreateTournamentView();
            createTournamentView.Show();
        }

        private void addDealerBtn_Click(object sender, RoutedEventArgs e)
        {
            DealerRegistrationView dealerRegistrationView = new DealerRegistrationView();
            dealerRegistrationView.Show();
        }

        private void playerRegBtn_Click(Object sender, RoutedEventArgs e)
        {
            AddRegistrationView addRegistrationView = new AddRegistrationView();
            addRegistrationView.Show();
        }

    }
}
