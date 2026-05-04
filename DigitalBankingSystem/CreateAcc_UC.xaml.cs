using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace DigitalBankingSystem
{
    /// <summary>
    /// Interaction logic for CreateAcc_UC.xaml
    /// </summary>
    public partial class CreateAcc_UC : UserControl
    {
        private string? fullName;
        private int? age;
        private string? nationalId;
        private string? phoneNumber;
        private string? address;
        private string? type;

        public CreateAcc_UC()
        {
            InitializeComponent();
        }

        private void userNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            fullName = userNameTB.Text;
        }

        private void userAgeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(userAgeTB.Text, out var parsedAge))
            {
                age = parsedAge;
            }
            else
            {
                age = null;
            }
        }

        private void userNationalIdTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            nationalId = userNationalIdTB.Text;
        }

        private void userPhoneNumberTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            phoneNumber = userPhoneNumberTB.Text;
        }

        private void userAddressTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            address = userAddressTB.Text;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string connection = "server=localhost;user=deskUser;password=1234;database=banking_system";

            using (var conn = new MySqlConnection(connection))
            {
                if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(nationalId))
                {
                    MessageBox.Show("Full name and National ID are required.");
                    return;
                }

                try
                {
                    conn.Open();

                    string query = "Insert into account (full_name, age, national_id, phone_number, address, account_type) VALUES (@fullName, @age, @nationalId, @phoneNumber, @address, @type)";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", fullName ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@age", age.HasValue ? (object)age.Value : DBNull.Value);
                        cmd.Parameters.AddWithValue("@nationalId", nationalId ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@address", address ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@type", type ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Account created successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to create account: {ex.Message}");
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton rb)
            {
                type = rb.Content.ToString();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = Window.GetWindow(this) as MainWindow;

            if(parentWindow != null)
            {
                parentWindow.DisplayArea.Content = new MainUC();
            }
        }
    }
}
