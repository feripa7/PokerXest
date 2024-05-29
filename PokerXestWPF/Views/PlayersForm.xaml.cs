using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokerXestWPF.Views
{
    /// <summary>
    /// Lógica de interacción para PlayersForm.xaml
    /// </summary>
    public partial class PlayersForm : Window
    {
        public PlayersForm()
        {
            InitializeComponent();
        }

        private async void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            
                var player = new PlayerModel()
                {
                    Dni = DniTextBox.Text,
                    NickName = AlcumeTextBox.Text,
                    Name = NomeTextBox.Text,
                    Surname = ApelidosTextBox.Text,
                    PhoneNumber = Convert.ToInt32(TelefonoTextBox.Text),
                    Email = CorreoTextBox.Text,
                    BirthdayDate = DateOnly.Parse(DataNacementoTextBox.Text)
                };
            
            var playerRep = new PlayerRepository();
            try
            {
                playerRep.Add(player);
                System.Windows.MessageBox.Show("Datos guardados exitosamente.");

            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
        }

        public void VolverButton_Click(object sender, RoutedEventArgs e)
        {
            AdminDashboardView adminDashboardView = new AdminDashboardView();
            adminDashboardView.Show();
            this.Close();
        }
    }
}
    