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
 
    public partial class PlayersView : UserControl
    {
        public PlayersView()
        {
            InitializeComponent();            
        }
        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            EditPlayerView editPlayerView = new EditPlayerView();
            editPlayerView.Show();
        }

        private void addBtn_Click(Object sender, RoutedEventArgs e)
        {
            AddPlayerView addPlayerView = new AddPlayerView();
            addPlayerView.Show();
        }
      
    }

}
