using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace CrawfordPOS
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class Customers
    {
        public Customers()
        {
            InitializeComponent();
            Occupationfill();
            Religionfill();
            SalesPersonfill();
            FoPfill();
        }

        public SqlConnection Con = new SqlConnection(@"Data Source=JMORGAN_SCHULPC;Initial Catalog=POS;Integrated Security=True");
        public SqlCommand Cmd;

        public void Occupationfill()
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM Occupation";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                JobcomboBox.Items.Add(dr["Description"].ToString());
            }
            Con.Close();
        }

        public void Religionfill()
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM Religion";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ReligioncomboBox.Items.Add(dr["Name"].ToString());
            }
            Con.Close();
        }

        public void SalesPersonfill()
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM SalesPersonnel";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                contactSalesmancomboBox.Items.Add(dr["Name"].ToString());
            }
            Con.Close();
        }

        public void FoPfill()
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM FOP";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                FOPcomboBox.Items.Add(dr["Form"].ToString());
            }
            Con.Close();
        }

        private void CustomerWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //var pOsDataset = (POSDataset)FindResource("pOSDataset");
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM Occupation WHERE Description = '" + JobcomboBox.Text + "'";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                jobCodeTextBox.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

      private void ReligioncomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM Religion WHERE Name = '" + ReligioncomboBox.Text + "'";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                religionCodeTextBox.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

        private void contactSalesmancomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM SalesPersonnel WHERE Name = '" + contactSalesmancomboBox.Text + "'";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                contactSalesmanCodeTextBox.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

        private void FOPcomboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Con.Open();
            Cmd = Con.CreateCommand();
            Cmd.CommandType = CommandType.Text;
            Cmd.CommandText = "SELECT * FROM FOP WHERE Form = '" + FOPcomboBox.Text + "'";
            Cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(Cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               formOfPaymentCodeTextBox.Text = dr["Code"].ToString();
            }
            Con.Close();
        }

        private void ViewButton_Click(object sender, RoutedEventArgs e)
        {
            CustomersCatalogue ss = new CustomersCatalogue();
            ss.Show();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM CustomerInfo WHERE Code = '" + codeTextBox.Text + "'", Con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Con.Open();
                cmd = Con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CustomerInfo SET Name = '" + nameTextBox.Text + "', HomeAddress = '" + homeAddressTextBox.Text + "'," +
                                  " HomeAddress = '" + homeAddressTextBox.Text + "', HomeNumber1 = '" + homeNumber1TextBox.Text + "', " +
                                  "HomeNumber2 = '" + homeNumber2TextBox.Text + "', JobCode = '" + jobCodeTextBox.Text + "', " +
                                  "OfficeAddress = '" + officeAddressTextBox.Text + "', OfficeNumber1 = '" + officeNumber1TextBox.Text + "', " +
                                  "OfficeNumber2 = '" + officeNumber2TextBox.Text + "', BirthDate = '" + birthDateDatePicker.Text + "', " +
                                  "ReligionCode = '" + religionCodeTextBox.Text + "', RegistrationDate = '" + registrationDateDatePicker.Text + "', " +
                                  "ContactSalesmanCode = '" + contactSalesmanCodeTextBox.Text + "', FormOfPaymentCode = '" + formOfPaymentCodeTextBox.Text + "'" +
                                  "Discount = '" + discountTextBox.Text + "' WHERE Code = '" + codeTextBox.Text + "'";
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            else
            {
                Con.Open();
                string query = "INSERT INTO CustomerInfo (Name,HomeAddress,HomeNumber1,HomeNumber2,JobCode,OfficeAddress,OfficeNumber1,OfficeNumber2,BirthDate,ReligionCode,RegistrationDate,ContactSalesmanCode,FormOfPaymentCode,Discount)" +
                               "VALUES ('" + nameTextBox.Text + "','" + homeAddressTextBox.Text + "','" + homeNumber1TextBox.Text + "'," +
                               "'" + homeNumber2TextBox.Text + "','" + jobCodeTextBox.Text + "','" + officeAddressTextBox.Text + "','" + officeNumber1TextBox.Text + "'," +
                               "'" + officeNumber2TextBox.Text + "','" + birthDateDatePicker.Text + "','" + religionCodeTextBox.Text + "'," +
                               "'" + registrationDateDatePicker.Text + "','" + contactSalesmanCodeTextBox.Text + "','" + formOfPaymentCodeTextBox.Text + "'," +
                               "'" + discountTextBox.Text + "')";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                sda.SelectCommand.ExecuteNonQuery();
                DataTable data = new DataTable();
                sda.Fill(data);
                Con.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
