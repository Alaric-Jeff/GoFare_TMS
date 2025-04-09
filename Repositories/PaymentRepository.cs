using System;
using System.Data.SqlClient;
using System.Diagnostics;
using IPT_TMS_GoFare.Models;

namespace IPT_TMS_GoFare.Repositories
{
    public class PaymentRepository
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=GoFare_Database;Integrated Security=True;";

        public bool Pay(WalletModel wallet, decimal payment)
        {
            if (wallet == null || wallet.client_id == 0)
            {
                Debug.WriteLine("Wallet or Client ID is null");
                return false;
            }

            try
            {
                if (wallet.loaned > 0)
                {
                    if (wallet.balance >= wallet.loaned)
                    {
                        wallet.balance -= wallet.loaned;
                        wallet.loaned = 0;
                        wallet.status = "Default";
                    }
                    else
                    {
                        Debug.WriteLine("Insufficient balance to settle the loan.");
                        return false; 
                    }
                }

                if (wallet.balance >= payment)
                {
                    wallet.balance -= payment;
                }
                else
                {
                    wallet.loaned = payment - wallet.balance;
                    wallet.balance = 0;
                    wallet.status = "Loaned";
                }


                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE WalletsModel SET balance = @balance, loaned = @loaned, status = @status WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@balance", wallet.balance);
                        command.Parameters.AddWithValue("@loaned", wallet.loaned);
                        command.Parameters.AddWithValue("@status", wallet.status);
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.ExecuteNonQuery();
                    }
                }


                return true;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
                return false;
            }
        }

    }
}
