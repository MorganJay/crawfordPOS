using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace CrawfordPOS
{
    /// <summary>
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees
    {
        public Employees()
        {
            InitializeComponent();
        }
        public SqlConnection Con = new SqlConnection(@"Data Source=JMORGAN_SCHULPC;Initial Catalog=POS;Integrated Security=True");

        public void RetrieveId()
        {
            try
            {
                const string query = "SELECT IDENT_CURRENT('SalesPersonnel')";
                if (Con.State == ConnectionState.Closed)
                {
                    Con.Open();
                }
                SqlCommand cmd = new SqlCommand(query, Con);
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                sda.SelectCommand.ExecuteNonQuery();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int value = int.Parse(reader[0].ToString()) + 1;
                    textBox_code.Text = value.ToString();
                }
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
            }
        }

        public void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM SalesPersonnel", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //salesPersonnelDataGrid.DataContext = dt;
        }
      
        private void button_list_Click(object sender, RoutedEventArgs e)
        {
            salesPersonnelDataGrid.Visibility = Visibility.Visible;
        }

        private void AdminRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Roles WHERE Role = '" + AdminRadioButton.Content + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                RoletextBlock.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

        private void AdminRadioButton_Copy1_Checked(object sender, RoutedEventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Roles WHERE Role = '" + AdminRadioButton_Copy1.Content + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                RoletextBlock.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

        private void AdminRadioButton_Copy_Checked(object sender, RoutedEventArgs e)
        {
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Roles WHERE Role = '" + AdminRadioButton_Copy.Content + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                RoletextBlock.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            button_Copy1.IsEnabled = true;
        }

        private void button_Copy1_Click(object sender, RoutedEventArgs e)
        {
            NameTextBox.Undo();
            AdminRadioButton.IsChecked = false;
            AdminRadioButton_Copy.IsChecked = false;
            AdminRadioButton_Copy1.IsChecked = false;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM SalesPersonnel WHERE Code = '" + textBox_code.Text + "'", Con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Con.Open();
                    cmd = Con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "UPDATE SalesPersonnel SET Code = '" + textBox_code.Text + "',Name = '" + NameTextBox.Text + "'," +
                                      "RoleCode = '" + RoletextBlock.Text + "' WHERE Code = '" + textBox_code.Text + "'";
                    cmd.ExecuteNonQuery();
                    Con.Close();
                }
                else
                {
                    //Con.Open();
                    //string query = "INSERT INTO SalesPersonnel (Code,Name,RoleCode) VALUES ('" + textBox_code.Text + "','" + NameTextBox.Text + "'," +
                    //               "'" + RoletextBlock.Text + "')";
                    //SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                    //sda.SelectCommand.ExecuteNonQuery();
                    //DataTable data = new DataTable();
                    //sda.Fill(data);
                    //Con.Close();
                }
            }
            catch (Exception)
            {
                //Ignore
            }
        }

        private void textBox_code_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            button_Copy1.IsEnabled = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RetrieveId();
            CrawfordPOS.CustomerDataset customerDataset = ((CrawfordPOS.CustomerDataset)(this.FindResource("customerDataset")));
            // Load data into the table SalesPersonnel. You can modify this code as needed.
            CrawfordPOS.CustomerDatasetTableAdapters.SalesPersonnelTableAdapter customerDatasetSalesPersonnelTableAdapter = new CrawfordPOS.CustomerDatasetTableAdapters.SalesPersonnelTableAdapter();
            customerDatasetSalesPersonnelTableAdapter.Fill(customerDataset.SalesPersonnel);
            System.Windows.Data.CollectionViewSource salesPersonnelViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("salesPersonnelViewSource")));
            salesPersonnelViewSource.View.MoveCurrentToFirst();
        }

        private void salesPersonnelDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            salesPersonnelDataGrid.Visibility = Visibility.Hidden;
        }
    }
}
