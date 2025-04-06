using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using IPT_TMS_GoFare.Models;

namespace IPT_TMS_GoFare.Repositories
{
    class WalletRepository
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=GoFare_Database;Integrated Security=True;Trust Server Certificate=True";

        public List<WalletModel> GetWallets()
        {
            var wallets = new List<WalletModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM WalletModel ORDER BY wallet_id ASC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WalletModel wallet = new WalletModel
                                {
                                    wallet_id = reader.GetInt32(0),
                                    client_id = reader.GetInt32(1),
                                    balance = reader.GetDecimal(2),
                                    status = reader.GetString(3),
                                    loaned = reader.GetDecimal(4),
                                    created_at = reader.GetDateTime(5).ToString()
                                };
                                wallets.Add(wallet);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            return wallets;
        }

        public WalletModel? GetWallet(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM WalletsModel WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new WalletModel
                                {
                                    wallet_id = reader.GetInt32(0),
                                    client_id = reader.GetInt32(1),
                                    balance = reader.GetDecimal(2),
                                    status = reader.GetString(3),
                                    loaned = reader.GetDecimal(4),
                                    created_at = reader.GetDateTime(5).ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
            return null;
        }

        public void CreateWallet(WalletModel wallet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO WalletModel (client_id, balance, status, loaned) VALUES (@client_id, @balance, @status, @loaned)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.Parameters.AddWithValue("@balance", wallet.balance);
                        command.Parameters.AddWithValue("@status", wallet.status);
                        command.Parameters.AddWithValue("@loaned", wallet.loaned);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void UpdateWallet(WalletModel wallet)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE WalletModel SET balance = @balance, status = @status, loaned = @loaned WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.Parameters.AddWithValue("@balance", wallet.balance);
                        command.Parameters.AddWithValue("@status", wallet.status);
                        command.Parameters.AddWithValue("@loaned", wallet.loaned);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void SubtractBalance(WalletModel wallet, decimal subtractionValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE WalletModel SET balance = @balance WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.Parameters.AddWithValue("@balance", wallet.balance - subtractionValue);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void AddBalance(WalletModel wallet, decimal addedValue)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE WalletModel SET balance = @balance WHERE client_id = @client_id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@client_id", wallet.client_id);
                        command.Parameters.AddWithValue("@balance", wallet.balance + addedValue);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void DeleteWallet(int id)
        {

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM WalletModel WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }
    }
}
