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
    public partial class DealersView : UserControl
    {
        public DealersView()
        {
            InitializeComponent();
        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {
            EditDealerView editDealerView = new EditDealerView();
            editDealerView.Show();
        }

        private void addBtn_Click(Object sender, RoutedEventArgs e)
        {
            AddDealerView addDealerView = new AddDealerView();
            addDealerView.Show();
        }

        private void deleteBtn_Click(Object sender, RoutedEventArgs e)
        {
            EditDealerView deleteDealerView = new EditDealerView();
            deleteDealerView.Show();
        }

    }
}
