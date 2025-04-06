using System;
using System.Data.SqlClient;
using System.Diagnostics;
using IPT_TMS_GoFare.Models;

namespace IPT_TMS_GoFare.Repositories
{
    public class PaymentRepository
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=GoFare_Database;Integrated Security=True;";

        public void Loan(WalletModel wallet, decimal payment)
        {
            if (wallet == null || wallet.client_id == 0)
            {
                Debug.WriteLine("Wallet or Client ID is null");
                return;
            }

            try
            {
                decimal newLoan = payment - wallet.balance;
                wallet.loaned += newLoan;
                wallet.balance = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE WalletsModel SET balance = @balance, loaned = @loaned WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@balance", wallet.balance);
                        command.Parameters.AddWithValue("@loaned", wallet.loaned);
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
            }
        }

        public void PayWithoutLoan(WalletModel wallet, decimal payment)
        {
            if (wallet == null || wallet.client_id == 0)
            {
                Debug.WriteLine("Wallet or Client ID is null");
                return;
            }

            try
            {
                if (wallet.balance < payment)
                {
                    Debug.WriteLine("Insufficient balance.");
                    return;
                }
                wallet.balance -= payment;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE WalletsModel SET balance = @balance WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@balance", wallet.balance);
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
            }
        }




        public void PayWithLoan(WalletModel wallet, decimal payment)
        {
            if (wallet == null || wallet.client_id == 0)
            {
                Debug.WriteLine("Wallet or Client ID is null");
                return;
            }

            try
            {
                if (wallet.loaned > 0)
                {
                    decimal payToLoan = Math.Min(wallet.loaned, payment);
                    wallet.loaned -= payToLoan;
                    payment -= payToLoan; 
                    if (payment > 0)
                    {
                        if (wallet.balance < payment)
                        {
                            Debug.WriteLine("Insufficient balance.");
                            return;
                        }
                        wallet.balance -= payment; 
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE WalletsModel SET balance = @balance, loaned = @loaned WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@balance", wallet.balance);
                        command.Parameters.AddWithValue("@loaned", wallet.loaned);
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception: {ex}");
            }
        }




    }
}
