using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPT_TMS_GoFare.Models;
using Microsoft.Data.SqlClient;

namespace IPT_TMS_GoFare.Repositories
{
    class RFIDRepository
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=GoFare_Database;Integrated Security=True;Trust Server Certificate=True";

        public List<RFIDModel> GetRFIDs()
        {
            var rfids = new List<RFIDModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM RFIDModel ORDER BY key_index ASC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                RFIDModel rfid = new RFIDModel
                                {
                                    key_index = reader.GetInt32(0),
                                    client_id = reader.GetInt32(1),
                                    rfid = reader.GetString(2),
                                    created_at = reader.GetDateTime(3).ToString()
                                };

                                rfids.Add(rfid);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }

            return rfids;
        }

        public RFIDModel? GetRFID(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM RFIDModel WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RFIDModel
                                {
                                    key_index = reader.GetInt32(0),
                                    client_id = reader.GetInt32(1),
                                    rfid = reader.GetString(2),
                                    created_at = reader.GetDateTime(3).ToString()
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




        public RFIDModel? GetRecordBasedOnRFID(string rfid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM RFIDModel WHERE rfid = @rfid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@rfid", SqlDbType.VarChar).Value = rfid;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RFIDModel
                                {
                                    key_index = reader.GetInt32(0),
                                    client_id = reader.GetInt32(1),
                                    rfid = reader.GetString(2),
                                    created_at = reader.IsDBNull(3) ? null : reader.GetDateTime(3).ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return null;
        }



        public void CreateRFID(RFIDModel rfid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO RFIDModel (client_id, rfid) VALUES (@client_id, @rfid)";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@client_id", rfid.client_id);
                        command.Parameters.AddWithValue("@rfid", rfid.rfid);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void UpdateRFID(RFIDModel rfid)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE RFIDModel SET rfid = @rfid WHERE client_id = @id";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", rfid.client_id);
                        command.Parameters.AddWithValue("@rfid", rfid.rfid);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public void DeleteRFID(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "DELETE FROM RFIDModel WHERE client_id = @id";
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
