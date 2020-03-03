using System;
using System.Windows;
using System.Windows.Threading;

namespace CrawfordPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(string role, string language)
        {
            InitializeComponent();
            StartClock();
            RoleTextBlock1.Text = role;
            LanguageTextBlock.Text = language;
            Yoruba();
        }

        public void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer(); 
             timer.Interval = TimeSpan.FromMilliseconds(1);
            timer.Tick += Tickevent;
            timer.Start(); 
        }

        private void Tickevent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            TimeTextBlock.Text = DateTime.Now.ToLongTimeString();
            DateTextBlock.Text = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
        }

        public void Verify()
        {
            Hide();
            var ss = new UserAccessWindow();
            ss.Show();
        }

        public void Yoruba()
        {
            if (LanguageTextBlock.Text != "YORUBA") return;
            ChangeItBackButton.Visibility = Visibility.Visible;
            LanguageButton.Visibility = Visibility.Hidden;
            SalesPointButton.Content = "ipo tita";
            ReportsButton.Content = "iroyin";
            FilesButton.Content = "awọn faili";
            LogOutButton.Content = "wọle jade";
            EmployeeButton.Content = "awọn abáni";
            StockListButton.Content = "akojọ ọja";
            CustomersButton.Content = "awon onibara";
            LanguageButton.Visibility = Visibility.Hidden;
        }

        private void MainWindow1_Loaded(object sender, RoutedEventArgs e)
        {
            StartClock();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if ((string)SalesPointButton.Content == @"ipo tita")
            {
                ButtonTextBlock.Text = "ipo tita";
            }
            else
            {
                ButtonTextBlock.Text = "SALES POINT";
            }
        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(@"Are you sure you want to quit?", @"", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) != MessageBoxResult.Yes)
            {
                MainWindow1.Close();
            }
        }

        private void reportsButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)ReportsButton.Content == "iroyin")
            {
                ButtonTextBlock.Text = "iroyin";
            }
            else
            {
                ButtonTextBlock.Text = "REPORTS";
            }
        }

        private void languageButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeItBackButton.Visibility = Visibility.Visible;
            LanguageButton.Visibility = Visibility.Hidden;
            SalesPointButton.Content = "ipo tita";
            ReportsButton.Content = "iroyin";
            FilesButton.Content = "awọn faili";
            LogOutButton.Content = "wọle jade";
            EmployeeButton.Content = "awọn abáni";
            StockListButton.Content = "akojọ ọja";
            CustomersButton.Content = "awon onibara";
        }

        private void changeItBackButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeItBackButton.Visibility = Visibility.Hidden;
            LanguageButton.Visibility = Visibility.Visible;
            SalesPointButton.Content = "SALES POINT";
            ReportsButton.Content = "REPORTS";
            FilesButton.Content = "FILES";
            LogOutButton.Content = "LOGOUT";
            EmployeeButton.Content = "EMPLOYEES";
            StockListButton.Content = "STOCK LIST";
            CustomersButton.Content = "CUSTOMERS";
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            Verify();
        }

        private void employeeButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)EmployeeButton.Content == @"awọn abáni")
            {
                ButtonTextBlock.Text = "awọn abáni";
            }
            else
            {
                ButtonTextBlock.Text = "EMPLOYEES";
            }
            Employees ss = new Employees();
            ss.Show();
        }

        private void StockListButton_Click(object sender, RoutedEventArgs e)
        {
            if ((string)StockListButton.Content == @"akojọ ọja")
            {
                ButtonTextBlock.Text = "akojọ ọja";
            }
            else
            {
                ButtonTextBlock.Text = "STOCKS LIST";
            }
        }
        
        private void CustomersButton_Click_1(object sender, RoutedEventArgs e)
        {
            if ((string)CustomersButton.Content == @"awon onibara")
            {
                ButtonTextBlock.Text = "awon onibara";
            }
            else
            {
                ButtonTextBlock.Text = "CUSTOMERS";
            }
            Customers ss = new Customers();
            ss.Show();
         }

        private void FilesButton_Click_1(object sender, RoutedEventArgs e)
        {
            if ((string)FilesButton.Content == @"awọn faili")
            {
                ButtonTextBlock.Text = "awọn faili";
            }
            else
            {
                ButtonTextBlock.Text = "FILES";
            }
        }

        private void EmployeeButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void ButtonStackPanel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ButtonStackPanel.Visibility = Visibility.Visible;
        }

        private void ButtonStackPanel_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ButtonStackPanel.Visibility = Visibility.Visible;
        }
    }
}
