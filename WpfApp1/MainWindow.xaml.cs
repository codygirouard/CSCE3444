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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool admin
        {
            get; private set;
        }
        
        public MainWindow()
        {
            InitializeComponent();
            admin = false;
        }

        private void CkInven_Click(object sender, RoutedEventArgs e)
        {
            this.Welcome.Visibility = Visibility.Hidden;
            this.Inventory.Visibility = Visibility.Visible;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (this.LoginButton.Content.Equals("Login"))
            {
                this.Inventory.Visibility = Visibility.Hidden;
                this.Login.Visibility = Visibility.Visible;
            }
            else
            {
                this.LoginButton.Content = "Login";
                this.LoginButton.Background = new SolidColorBrush(Color.FromArgb(255, 119, 218, 146));
                admin = false;
            }
            
        }

        private void Username_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.Username.Text == "Username")
            {
                this.Username.Text = "";
            }
        }

        private void Username_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (this.Username.Text == "")
            {
                this.Username.Text = "Username";
            }
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.Password.Password.Length == 0)
            {
                this.PasswordCover.Visibility = Visibility.Visible;
            }
            else
            {
                this.PasswordCover.Visibility = Visibility.Hidden;
            }
        }

        private void PasswordCover_Click(object sender, RoutedEventArgs e)
        {
            this.PasswordCover.Visibility = Visibility.Hidden;
            this.Password.Focus();
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.Password.Password.Length == 0)
            {
                this.PasswordCover.Visibility = Visibility.Visible;
            }
            else
            {
                this.PasswordCover.Visibility = Visibility.Hidden;
            }
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CompleteLogin_Click(null, null);
            }
        }
        private void CompleteLogin_Click(object sender, RoutedEventArgs e)
        {
            if (this.Username.Text == "owner" && this.Password.Password == "eagle")
            {
                admin = true;
                this.Login.Visibility = Visibility.Hidden;
                this.Inventory.Visibility = Visibility.Visible;
                this.LoginButton.Content = "Logout";
                this.LoginButton.Background = new SolidColorBrush(Color.FromArgb(255, 236, 86, 62));
                this.Password.Password = "";
                this.Username.Text = "Username";
            }
            else
            {
                MessageBox.Show("Try again", "Incorrect Login");
                this.Password.Password = "";
                this.Username.Text = "Username";
                this.Login.Visibility = Visibility.Hidden;
                this.Inventory.Visibility = Visibility.Visible;
            }
        }

        private void Username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                this.Password.Focus();
            }
        }
    }
}