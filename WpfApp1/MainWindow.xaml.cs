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

        string[] tools = { "Screwdriver", "Hammer", "Plier", "Wrench", "Ladder", "Clamp", "Tape Measure", "Tool Belt", "Axe", "Chisel", "Drill", "Saw", "Sander", "Air Compressor", "Staple Gun", "Nail", "Screw", "Shovel", "Caliper", "Ruler" };
        int[] stocks = { 13, 6, 0, 7, 22, 15, 1, 20, 18, 19, 10, 2, 0, 14, 44, 26, 7, 16, 19, 20 };
        double[] prices = { 12.99, 21.50, 16.00, 15.99, 9.99, 22.49, 30.00, 23.99, 6.50, 18.99, 19.99, 33.33, 27.89, 22.22, 9.99, 0.50, 0.50, 20.00, 4.99, 1.99 };
        string[] descs = { "A screwdriver is a tool, manual or powered, used for screwing and unscrewing screws.", "A hammer is a tool consisting of a weighted \"head\" fixed to a long handle that is swung to deliver an impact to a small area of an object.", "Pliers are a hand tool used to hold objects firmly.", "A wrench or spanner is a tool used to provide grip and mechanical advantage in applying torque to turn objects—usually rotary fasteners, such as nuts and bolts—or keep them from turning.", "A ladder is a vertical or inclined set of rungs or steps.", "A clamp is a fastening device used to hold or secure objects tightly together to prevent movement or separation through the application of inward pressure.", "A tape measure or measuring tape is a flexible ruler used to measure size or distance.", "A belt for carrying tools; a utility belt.", "An axe is an implement that has been used for millennia to shape, split and cut wood, to harvest timber, as a weapon, and as a ceremonial or heraldic symbol.", "A chisel is a tool with a characteristically shaped cutting edge of blade on its end, for carving or cutting a hard material such as wood, stone, or metal by hand, struck with a mallet, or mechanical power.", "A drill or drilling machine is a tool primarily used for making round holes or driving fasteners.", "A saw is a tool consisting of a tough blade, wire, or chain with a hard toothed edge.", "A sander is a power tool used to smooth surfaces by abrasion with sandpaper.", "An air compressor is a pneumatic device that converts power into potential energy stored in pressurized air (i.e., compressed air).", "A staple gun or powered stapler is a hand-held machine used to drive heavy metal staples into wood, plastic, or masonry.", "A nail is a small object made of metal which is used as a fastener, as a peg to hang something, or sometimes as a decoration.", "A screw and a bolt are similar types of fastener typically made of metal, and characterized by a helical ridge, known as a male thread.", "A shovel is a tool for digging, lifting, and moving bulk materials, such as soil, coal, gravel, snow, sand, or ore.", "A caliper is a device used to measure the dimensions of an object.", "A ruler, sometimes called a rule or line gauge, is a device used in geometry and technical drawing, as well as the engineering and construction industries, to measure distances or draw straight lines." };
        int item = 0;
        public MainWindow()
        {
            InitializeComponent();
            admin = false;
        }

        private void CkInven_Click(object sender, RoutedEventArgs e) // send UI from main page to inventory list
        {
            this.Welcome.Visibility = Visibility.Hidden;
            this.Inventory.Visibility = Visibility.Visible;
            this.txt1.Text = tools[0];
            this.img1.Source = new BitmapImage(new Uri("Pictures/" + tools[0] + ".png", UriKind.Relative)); 
            this.txt2.Text = tools[1];
            this.img2.Source = new BitmapImage(new Uri("Pictures/" + tools[1] + ".png", UriKind.Relative));
            this.txt3.Text = tools[2];
            this.img3.Source = new BitmapImage(new Uri("Pictures/" + tools[2] + ".png", UriKind.Relative));
            this.txt4.Text = tools[3];
            this.img4.Source = new BitmapImage(new Uri("Pictures/" + tools[3] + ".png", UriKind.Relative));
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
            if (this.PageNum.Text == "5")
            {
                MessageBox.Show("This is the last page.", "No Pages Left");
                return;
            }
            int currPage = Int16.Parse(this.PageNum.Text);
            currPage++;
            this.PageNum.Text = currPage.ToString();
            this.txt1.Text = tools[0 + (currPage - 1) * 4];
            this.img1.Source = new BitmapImage(new Uri("Pictures/" + tools[0 + (currPage - 1) * 4] + ".png", UriKind.Relative));
            this.txt2.Text = tools[1 + (currPage - 1) * 4];
            this.img2.Source = new BitmapImage(new Uri("Pictures/" + tools[1 + (currPage - 1) * 4] + ".png", UriKind.Relative));
            this.txt3.Text = tools[2 + (currPage - 1) * 4];
            this.img3.Source = new BitmapImage(new Uri("Pictures/" + tools[2 + (currPage - 1) * 4] + ".png", UriKind.Relative));
            this.txt4.Text = tools[3 + (currPage - 1) * 4];
            this.img4.Source = new BitmapImage(new Uri("Pictures/" + tools[3 + (currPage - 1) * 4] + ".png", UriKind.Relative));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.PageNum.Text == "1")
            {
                MessageBox.Show("This is the first page.", "Cannot Go Back");
                return;
            }
            int currPage = Int16.Parse(this.PageNum.Text);
            currPage--;
            this.PageNum.Text = currPage.ToString();
            this.txt1.Text = tools[0 + (currPage - 1) * 4];
            this.img1.Source = new BitmapImage(new Uri("Pictures/" + tools[0 + (currPage - 1) * 4] + ".png", UriKind.Relative));
            this.txt2.Text = tools[1 + (currPage - 1) * 4];
            this.img2.Source = new BitmapImage(new Uri("Pictures/" + tools[1 + (currPage - 1) * 4] + ".png", UriKind.Relative));
            this.txt3.Text = tools[2 + (currPage - 1) * 4];
            this.img3.Source = new BitmapImage(new Uri("Pictures/" + tools[2 + (currPage - 1) * 4] + ".png", UriKind.Relative));
            this.txt4.Text = tools[3 + (currPage - 1) * 4];
            this.img4.Source = new BitmapImage(new Uri("Pictures/" + tools[3 + (currPage - 1) * 4] + ".png", UriKind.Relative));
        }

        private void Item_Click(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            int offset = 0;
            switch (b.Name)
            {
                case "Button1":
                    offset = 0;
                    break;
                case "Button2":
                    offset = 1;
                    break;
                case "Button3":
                    offset = 2;
                    break;
                case "Button4":
                    offset = 3;
                    break;
                default:
                    MessageBox.Show("Error Button Not Found");
                    break;
            }
            item = offset + 4 * (Int16.Parse(this.PageNum.Text) - 1);
            this.Price.Text = "$" + String.Format("{0:0.00}", prices[item]);
            this.Stock.Text = "In Stock: " + stocks[item].ToString();
            this.txt.Text = tools[item];
            this.Desc.Text = descs[item];
            this.StockText.Text = stocks[item].ToString();
            this.img.Source = new BitmapImage(new Uri("Pictures/" + tools[item] + ".png", UriKind.Relative));
            if (admin)
            {
                this.OwnView.Visibility = Visibility.Visible;
                this.CustView.Visibility = Visibility.Hidden;
            }
            else
            {
                this.OwnView.Visibility = Visibility.Hidden;
                this.CustView.Visibility = Visibility.Visible;
            }
            this.Inventory.Visibility = Visibility.Hidden;
            this.Item.Visibility = Visibility.Visible;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Inventory.Visibility = Visibility.Visible;
            this.Item.Visibility = Visibility.Hidden;
        }

        private void PurchaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (stocks[item] < 1)
            {
                MessageBox.Show("Out of Stock", "No Inventory Left");
                return;
            }
            stocks[item]--;
            this.Stock.Text = "In Stock: " + stocks[item].ToString();
        }

        private void StockButton_Click(object sender, RoutedEventArgs e)
        {
            int stock = 0;
            bool isNum = int.TryParse(this.StockText.Text, out stock);
            if (!isNum)
            {
                MessageBox.Show("Not a number entry", "Try Again");
                return;
            }
            if (stock < 0)
            {
                MessageBox.Show("Please enter a number equal to or greater than 0", "Incorrect Number Entry");
                return;
            }

            stocks[item] = stock;
            this.Stock.Text = "In Stock: " + stocks[item].ToString();
        }
    }
}