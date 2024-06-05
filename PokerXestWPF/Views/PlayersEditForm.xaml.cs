using Microsoft.Data.Sqlite;
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
    /// <summary>
    /// Lógica de interacción para PlayersEditForm.xaml
    /// </summary>
    public partial class PlayersEditForm : Window
    {
        public PlayersEditForm()
        {
            InitializeComponent();
        }

        private async void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private async void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void saveBtn_Click(object sender, RoutedEventArgs e)
        {

            var player = new PlayerModel()
            {
                Dni = playerDniEdit.Text,
                NickName = playerNicknameEdit.Text,
                Name = playerNameEdit.Text,
                Surname = playerSurnameEdit.Text,
                PhoneNumber = Convert.ToInt32(playerPhoneNumberEdit.Text),
                Email = playerEmailEdit.Text,
                BirthdayDate = DateTime.Parse(playerBirthdayDateEdit.Text)
            };

            var playerRep = new PlayerRepository();
            try
            {
                if (IsValidDNI(player.Dni) && IsOver18(player.BirthdayDate))
                {
                    playerRep.Edit(player);
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

        public bool IsValidDNI(string dni)
        {
            if (dni.Length != 9) return false;
            string numbersPart = dni.Substring(0, 8);
            string letterPart = dni.Substring(8, 1);
            if (!int.TryParse(numbersPart, out int numbers)) return false;
            char correctLetter = CalculateDNILetter(numbers);
            return letterPart[0] == correctLetter;
        }

        public char CalculateDNILetter(int numbers)
        {
            string letters = "TRWAGMYFPDXBNJZSQVHLCKE";
            return letters[numbers % 23];
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

        public void backBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
