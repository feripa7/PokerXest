using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace PokerXestWPF.Views
{
      public partial class AddPlayerView : Window
    {
        public AddPlayerView()
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
            
                var player = new PlayerModel()
                {
                    Dni = playerDni.Text,
                    NickName = playerNickname.Text,
                    Name = playerName.Text,
                    Surname = playerSurname.Text,
                    PhoneNumber = Convert.ToInt32(playerPhoneNumber.Text),
                    Email = playerEmail.Text,
                    BirthdayDate = DateTime.Parse(playerBirthdayDate.Text)
                };
            
            var playerRep = new PlayerRepository();
            try
            {
                if(IsValidDNI(player.Dni) && IsOver18(player.BirthdayDate))
                {
                    playerRep.Add(player);
                    System.Windows.MessageBox.Show("Datos guardados exitosamente.");
                }
                else
                {
                    System.Windows.MessageBox.Show("DNI incorrecto o menor de edad");
                }

            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error");
            }
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
    