﻿using System;
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

        public void Crear_Click(object sender, RoutedEventArgs e)
        {
            PlayersForm playersForm = new PlayersForm();    
            playersForm.Show();
           
        }

       public void editarButton_Click(object sender, RoutedEventArgs e)
        {
            PlayersEditForm editForm = new PlayersEditForm();
            editForm.Show();
        }
        public void eliminarBtn_Click(object sender, RoutedEventArgs e) 
        { 
            PlayersForm eliminarForm = new PlayersForm();
            eliminarForm.Show();
        }
    }
}
