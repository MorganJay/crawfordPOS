using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Data;

namespace CrawfordPOS
{
    /// <summary>
    /// Interaction logic for UserAccessWindow.xaml
    /// </summary>
    public partial class UserAccessWindow
    {
        public UserAccessWindow()
        {
            InitializeComponent();
            AccessCodeTextBox.Focus();
            UndoButton.Visibility = Visibility.Hidden;
        }

        public void Verify()
        {
            var ss = new UserAccessWindow();
            ss.Show();
        }

        public SqlConnection Con = new SqlConnection(@"Data Source=JMORGAN_SCHULPC;Initial Catalog=POS;Integrated Security=True");

        private void UserVerification_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                UserVerification.Close();
            }
        }

      public void Access()
        {
            if (AccessCodeTextBox.Text != string.Empty || PassCodePasswordBox.Password != string.Empty)
            {
                if (LanguageSwitchButton.Visibility == Visibility.Hidden)
                {
                    string query = "SELECT * FROM [Login View] WHERE Name = '" + AccessCodeTextBox.Text + "'" +
                                   " AND PassCode = '" + PassCodePasswordBox.Password + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        Hide();
                        MainWindow ss = new MainWindow(dt.Rows[0][0].ToString(), "YORUBA");
                        ss.Show();
                    }
                    else if (LanguageSwitchButton.Visibility == Visibility.Hidden)
                    {
                        MessageBox.Show(@"Ti kọ iraye si", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(@"ACCESS DENIED", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    string query = "SELECT * FROM [Login View] WHERE Name = '" + AccessCodeTextBox.Text + "'" +
                                   " AND PassCode = '" + PassCodePasswordBox.Password + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        Hide();
                        MainWindow ss = new MainWindow(dt.Rows[0][0].ToString(), "");
                        ss.Show();
                    }
                    else if (LanguageSwitchButton.Visibility == Visibility.Hidden)
                    {
                        MessageBox.Show(@"Ti kọ iraye si", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        MessageBox.Show(@"ACCESS DENIED", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
            else if (LanguageSwitchButton.Visibility != Visibility.Visible)
            {
                MessageBox.Show(@"Ti kọ iraye si", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(@"ACCESS DENIED", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void GetName()
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Login View] WHERE Code = '" + AccessCodeTextBox.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                AccessCodeTextBox.Text = dr["Name"].ToString();
            }
            Con.Close();
        }

        private void accessCodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Access();
            }
        }

        private void accessCodeTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            GetName();
        }

        private void languageSwitchButton_Click(object sender, RoutedEventArgs e)
        {
            UndoButton.Visibility = Visibility.Visible;
            LanguageSwitchButton.Visibility = Visibility.Hidden;
            TextBlock.Text = "Koodu wiwọle";
            TextBlockCopy.Text = "Ọrọigbaniwọle koodu iwọle";
            AccessCodeTextBox.Clear();
            PassCodePasswordBox.Clear();
        }

        private void undoButton_Click(object sender, RoutedEventArgs e)
        {
            UndoButton.Visibility = Visibility.Hidden;
            LanguageSwitchButton.Visibility = Visibility.Visible;
            TextBlockCopy.Text = "Password Code";
            TextBlock.Text = "Access Code";
            AccessCodeTextBox.Clear();
            PassCodePasswordBox.Clear();
        }

        private void UserVerification_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Access();
        }
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void accessCodeTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
        }

        private void PassCodePasswordBox_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Access();
            }
        }
    }
}
