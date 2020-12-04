using Microsoft.SqlServer.Server;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool admin //true is owner is logged in
        {
            get; private set;
        }
        
        public MainWindow()
        {
            InitializeComponent();
            admin = false;
            Tool tempTool = new Tool();
        }
        public void UpdateToolInfoPage(string nameOfTool)  // function to access database and update ToolsInfo page
        {
            // getting the data from the database
            DataAccess db = new DataAccess();
            Tool obj = db.GetInfo(nameOfTool);

            // Update textboxes
            DescriptionBox.Text = obj.Description;          
            Name.Text = obj.Name;
            Price.Text = "$" + obj.Price.ToString();
            StockNum.Text = obj.Quantity.ToString();
        }

        private void CkInven_Click(object sender, RoutedEventArgs e) // send UI from main page to inventory list
        {
            this.Welcome.Visibility = Visibility.Hidden;
            this.Inventory.Visibility = Visibility.Visible;
        }

        private void Login_Click(object sender, RoutedEventArgs e) // send UI from inventory list to owner login
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

        private void Username_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) // empties the username box when the user clicks the username box
        {
            if (this.Username.Text == "Username")
            {
                this.Username.Text = "";
            }
        }

        private void Username_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) // if nothing was entered in the username box when left, replace text with "username"
        {
            if (this.Username.Text == "")
            {
                this.Username.Text = "Username";
            }
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e) // if the password is empty make the "Password" overlay visible, if something is entered in the password make it invisible
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

        private void PasswordCover_Click(object sender, RoutedEventArgs e) // When the password box is clicked, set the overlay to invis and set user's focus to the password box
        {
            this.PasswordCover.Visibility = Visibility.Hidden;
            this.Password.Focus();
        }

        private void Password_LostFocus(object sender, RoutedEventArgs e) // if the password is empty, make the overlay visible
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

        private void Password_KeyDown(object sender, KeyEventArgs e) // if the user presses enter in the password box, act as if they pressed the login button
        {
            if (e.Key == Key.Enter)
            {
                CompleteLogin_Click(null, null);
            }
        }
        private void CompleteLogin_Click(object sender, RoutedEventArgs e) // login button is pressed
        {
            if (this.Username.Text == "owner" && this.Password.Password == "eagle") //if password and user are correct 
            {
                admin = true; // system now shows item pages that allow stock to be updated
                this.Login.Visibility = Visibility.Hidden; 
                this.Inventory.Visibility = Visibility.Visible;
                this.LoginButton.Content = "Logout";
                this.LoginButton.Background = new SolidColorBrush(Color.FromArgb(255, 236, 86, 62));
                this.Password.Password = "";
                this.Username.Text = "Username";
            }
            else // pass and user were incorrect
            {
                MessageBox.Show("Try again", "Incorrect Login");
                this.Password.Password = "";
                this.Username.Text = "Username";
                this.Login.Visibility = Visibility.Hidden;
                this.Inventory.Visibility = Visibility.Visible;
            }
        }

        private void Username_KeyDown(object sender, KeyEventArgs e) // if tab is pressed while typing in the username, bring focus to the password box
        {
            if (e.Key == Key.Tab)
            {
                this.Password.Focus();
            }
        }
        private void Forward_Click(object sender, RoutedEventArgs e)
        {
            this.Inventory.Visibility = Visibility.Hidden;
            this.Inventory2.Visibility = Visibility.Visible;
        }
        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            this.Inventory2.Visibility = Visibility.Hidden;
            this.Inventory.Visibility = Visibility.Visible;
        }
        private void LeaveScrewdriver_Click(object sender, RoutedEventArgs e) // goes back to inventory page from Screwdrive Info page
        {
            this.ToolsInfo.Visibility = Visibility.Hidden;
            this.Inventory.Visibility = Visibility.Visible;
            
        }

        private void ScrewdriverInfo_Click(object sender, RoutedEventArgs e) // goes to screwdriver Information
        {
            this.Inventory.Visibility = Visibility.Hidden;
            this.ToolsInfo.Visibility = Visibility.Visible;
            UpdateToolInfoPage("Screwdriver");    
        }
        private void HammerInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Inventory.Visibility = Visibility.Hidden;
            this.ToolsInfo.Visibility = Visibility.Visible;
            UpdateToolInfoPage("Hammer");
        }
        private void PliersInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Inventory.Visibility = Visibility.Hidden;
            this.ToolsInfo.Visibility = Visibility.Visible;
            UpdateToolInfoPage("Pliers");
        }
        private void WrenchInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Inventory.Visibility = Visibility.Hidden;
            this.ToolsInfo.Visibility = Visibility.Visible;
            UpdateToolInfoPage("Wrench");
        }


        private void PurchaseSD_Click(object sender, RoutedEventArgs e) // purchase stock button
        {

        }

        private void Item_Description_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
