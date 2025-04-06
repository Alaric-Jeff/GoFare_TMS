using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPT_TMS_GoFare.Models;
using Microsoft.Data.SqlClient;

namespace IPT_TMS_GoFare.Repositories
{
    class ClientRepository
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=GoFare_Database;Integrated Security=True;Trust Server Certificate=True";

        public List<ClientModel> GetClients()
        {
            var clients = new List<ClientModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM ClientsModel ORDER BY client_id ASC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientModel client = new ClientModel();

                                client.client_id = reader.GetInt32(0);
                                client.first_name = reader.GetString(1);
                                client.last_name = reader.GetString(2);
                                client.middle_name = reader.GetString(3);
                                client.age = reader.GetInt32(4);
                                client.address = reader.GetString(5);
                                client.gender = reader.GetString(6);
                                client.created_at = reader.GetDateTime(7).ToString();

                                clients.Add(client);
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }

            return clients;
        }

        public ClientModel? GetClient(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM ClientsModel WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ClientModel client = new ClientModel();
                                client.client_id = reader.GetInt32(0);
                                client.first_name = reader.GetString(1);
                                client.last_name = reader.GetString(2);
                                client.middle_name = reader.GetString(3);
                                client.age = reader.GetInt32(4);
                                client.address = reader.GetString(5);
                                client.gender = reader.GetString(6);
                                client.created_at = reader.GetDateTime(7).ToString();

                                return client;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }

            return null;
        }

        public void CreateClient(ClientModel client)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO ClientModel" +
                                 "(first_name, last_name, middle_name, age, address, gender) VALUES " +
                                 "(@firstname, @lastname, @middlename, @age, @address, @gender)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@firstname", client.first_name);
                        command.Parameters.AddWithValue("@lastname", client.last_name);
                        command.Parameters.AddWithValue("@middlename", client.middle_name);
                        command.Parameters.AddWithValue("@age", client.age);
                        command.Parameters.AddWithValue("@address", client.address);
                        command.Parameters.AddWithValue("@gender", client.gender);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }

        }

        public void UpdateClient(ClientModel client)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE ClientModel " +
                                "SET first_name = @firstname, last_name = @lastname, " +
                                "middle_name = @middlename, age = @age, " +
                                "address = @address, gender = @gender " +
                                "WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", client.client_id);
                        command.Parameters.AddWithValue("@firstname", client.first_name);
                        command.Parameters.AddWithValue("@lastname", client.last_name);
                        command.Parameters.AddWithValue("@middlename", client.middle_name);
                        command.Parameters.AddWithValue("@age", client.age);
                        command.Parameters.AddWithValue("@address", client.address);
                        command.Parameters.AddWithValue("@gender", client.gender);
                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }
        }

        public void DeleteClient (int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM ClientModel WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.ToString()}");
            }
        }

    }
}
