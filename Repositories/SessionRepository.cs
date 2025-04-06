using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using IPT_TMS_GoFare.Models;

namespace IPT_TMS_GoFare.Repositories
{
    class SessionRepository
    {
        private readonly string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=GoFare_Database;Integrated Security=True;";

        public List<SessionModel> GetSessions()
        {
            var sessions = new List<SessionModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM SessionModel ORDER BY session_id ASC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                SessionModel session = new SessionModel
                                {
                                    session_id = reader.GetInt32(0),
                                    rfid = reader.GetString(1),
                                    pick_up = reader.GetString(2),
                                    drop_off = reader.GetString(3)
                                };
                                sessions.Add(session);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return sessions;
        }

        public SessionModel? GetSession(string rfid)
        {
            if (string.IsNullOrEmpty(rfid))
            {
                Console.WriteLine("RFID is null or empty.");
                return null;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT session_id, rfid, pick_up, drop_off FROM SessionModel WHERE rfid = @rfid";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rfid", rfid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new SessionModel
                                {
                                    session_id = reader.GetInt32(reader.GetOrdinal("session_id")),
                                    rfid = reader.GetString(reader.GetOrdinal("rfid")),
                                    pick_up = reader.GetString(reader.GetOrdinal("pick_up")),
                                    drop_off = reader.IsDBNull(reader.GetOrdinal("drop_off")) ? null : reader.GetString(reader.GetOrdinal("drop_off"))
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

        public void AddSession(string rfid, string pick_up)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO SessionModel (rfid, pick_up) VALUES (@rfid, @pick_up)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@rfid", SqlDbType.VarChar).Value = rfid;
                        command.Parameters.Add("@pick_up", SqlDbType.VarChar).Value = pick_up;
                        int result = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {result}");
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to add {rfid}: {ex.Message}");
            }
        }

        public void RemoveSession(string rfid)
        {
            if (rfid == null)
            {
                Console.WriteLine("RFID is null.");
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string session = "DELETE FROM SessionModel WHERE rfid = @rfid";
                    using (SqlCommand command = new SqlCommand(session, connection))
                    {
                        command.Parameters.AddWithValue("@rfid", rfid);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
            }
        }

        public bool FindSession(string rfid)
        {
            if (rfid == null)
            {
                Console.WriteLine("There's no Session Found.");
                return false;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM SessionModel WHERE rfid = @rfid";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rfid", rfid);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return false;
        }

        public void UpdateDropOff(string rfid, string drop_off)
        {
            if (string.IsNullOrEmpty(rfid))
            {
                Console.WriteLine("RFID is null or empty.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE SessionModel SET drop_off = @drop_off WHERE rfid = @rfid";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@drop_off", drop_off);
                        command.Parameters.AddWithValue("@rfid", rfid);
                        int result = command.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected: {result}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
