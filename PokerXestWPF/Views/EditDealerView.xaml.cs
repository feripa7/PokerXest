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
       public partial class EditDealerView : Window
    {
        public EditDealerView()
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

        private void backBtn_Click(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void saveBtn_Click(Object sender, RoutedEventArgs e)
        {
            var dealer = new DealerModel()
            {
                Dni = dealerDniEdit.Text,                
                Name = dealerNameEdit.Text,
                Surname = dealerSurnameEdit.Text,
                Salary = Convert.ToDouble(dealerSalaryEdit.Text),
                Email = dealerEmailEdit.Text,
                
            };

            var dealerRep = new DealerRepository();
            try
            {
                if (IsValidDNI(dealer.Dni))
                {
                    dealerRep.Edit(dealer);
                    System.Windows.MessageBox.Show("Datos guardados exitosamente.");
                }
                else
                {
                    System.Windows.MessageBox.Show("DNI incorrecto o menor de edad");
                }

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }

        private void deleteBtn_Click(Object sender, RoutedEventArgs e)
        {
            var dealerRep = new DealerRepository();
            try
            {
                dealerRep.Remove(dealerDniEdit.Text);
                System.Windows.MessageBox.Show("Repartidor eliminado correctamente");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public bool IsValidDNI(string dni)
        {
            Regex dniRegex = new Regex(@"^\d{8}[A-HJ-NP-TV-Z]$");
            return dniRegex.IsMatch(dni);
        }

        public bool IsOver18(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad >= 18;
        }

    }
}
