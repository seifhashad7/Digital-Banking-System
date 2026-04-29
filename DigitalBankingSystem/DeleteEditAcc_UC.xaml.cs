using MySql.Data.MySqlClient;
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

namespace DigitalBankingSystem
{
    /// <summary>
    /// Interaction logic for DeleteEditAcc_UC.xaml
    /// </summary>
    public partial class DeleteEditAcc_UC : UserControl
    {
        private int? accountId;
        public DeleteEditAcc_UC()
        {
            InitializeComponent();
        }

        private void bankAccTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(int.TryParse(bankAccTB.Text, out int bankAccId))
            {
                accountId = bankAccId;
            }
            else
            {
                accountId = null;
            }
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string connection = "server=localhost;user=deskUser;password=1234;database=banking_system";

            using (var conn = new MySqlConnection(connection))
            {
                try
                {
                    conn.Open();

                    string query = "delete from account where id = @accountId";

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@accountId", accountId ?? (object)DBNull.Value);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Account deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No account found with this id!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database error: " + ex.Message);    
                }
            }
        }
    }
}
