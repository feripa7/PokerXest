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
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Runtime;
using System.Windows.Interop;

namespace PokerXestWPF.Views
{
    /// <summary>
    /// Lógica de interacción para AdminDashboardView.xaml
    /// </summary>
    public partial class AdminDashboardView : Window
    {
        public AdminDashboardView()
        {
            InitializeComponent();
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int sMsg, int wParam, int lParam);


        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0); 
        }

        private void pnlControlBar_MouseEnter(object sender, MouseButtonEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void maximizeBtn_Click(object sender, RoutedEventArgs e)
        {
           if(this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
           else this.WindowState = WindowState.Normal;  
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            LoginView loginView = new LoginView();
            loginView.Show();
            this.Close();
        }
    }
}
