using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddDealerView : Window
    {
        public AddDealerView()
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

        private void saveBtn_Click(Object sender, RoutedEventArgs e)
        {
            var dealer = new DealerModel()
            {
                Dni = dealerDni.Text,             
                Name = dealerName.Text,
                Surname = dealerSurname.Text,
                Salary = Convert.ToDouble(dealerSalary.Text),
                Email = dealerEmail.Text,
                
            };

            var dealerRep = new DealerRepository();
            try
            {
                if (IsValidDNI(dealer.Dni))
                {
                    dealerRep.Add(dealer);
                    System.Windows.MessageBox.Show("Datos guardados exitosamente.");
                }
                else
                {
                    System.Windows.MessageBox.Show("DNI incorrecto ou menor de edad");
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }

        public bool IsValidDNI(string dni)
        {
            Regex dniRegex = new Regex(@"^\d{8}[A-HJ-NP-TV-Z]$");
            return dniRegex.IsMatch(dni);
        }

    }
}
