using Google.Protobuf.WellKnownTypes;
using IMoocService;
using MoocModel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace MoocApi.Controllers
{
    public class UserServiceDB : IUserServiceDB
    {
        private readonly string _connectionString;

        public UserServiceDB(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }

        public bool AddUser(User user)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();
                string sql = "INSERT INTO user(UserName, Email, Phone, Gender, Address, Password)"
                            +
                            "VALUES (@username, @email, @phone, @gender, @address, @password)";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@phone", user.Phone);
                command.Parameters.AddWithValue("@gender", (int)user.Gender);
                command.Parameters.AddWithValue("@address", user.Address);
                command.Parameters.AddWithValue("@password", user.Password);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding User: {ex.Message}");
                return false;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                string databaseName = "moocdb";
                string tableName = "user";

                string sql = $"UPDATE {databaseName}.`{tableName}` SET UserName = @username, " +
                    $"Email = @email, " + $"Phone = @phone, Gender = @gender, Address = @address, " +
                    $"Password = @password " + $"WHERE Id = @id";

                #region Debug
                Console.WriteLine($"=== UPDATE USER DEBUG ===");
                Console.WriteLine($"SQL: {sql}");
                Console.WriteLine($"User ID: {user.Id}");
                Console.WriteLine($"UserName: {user.UserName}");
                Console.WriteLine($"Email: {user.Email}");
                #endregion

                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@username", user.UserName);
                command.Parameters.AddWithValue("@email", user.Email);
                command.Parameters.AddWithValue("@phone", user.Phone);
                command.Parameters.AddWithValue("@gender", (int)user.Gender);
                command.Parameters.AddWithValue("@address", user.Address);
                command.Parameters.AddWithValue("@password", user.Password);
                command.Parameters.AddWithValue("@id", user.Id);

                Console.WriteLine($"About to execute UPDATE..."); //Debug
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine($"Numer of rows affected: {rowsAffected}");
                Console.WriteLine($"=== END DEBUG ==="); //Debug

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter Catch Clause");
                Console.WriteLine($"Error updating User: {ex.Message}");
                return false;
            }
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                string databaseName = "moocdb";
                string tableName = "user";

                string sql = $"Delete from {databaseName}.`{tableName}` WHERE Id = @id";
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", userId);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting User: {ex.Message}");
                return false;
            }
        }

        public List<User> GetAllUserWithDataTable()
        {
            List<User> users = new List<User>();
            string databaseName = "moocdb";
            string tableName = "user";

            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                string sql = $"SELECT * FROM {databaseName}.`{tableName}` WHERE 1 = @parm";
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@parm", 1);

                using var reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);

                foreach (DataRow row in dataTable.Rows)
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        UserName = row["UserName"].ToString(),
                        Email = row["Email"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Gender = (GenderEnum)Convert.ToInt32(row["Gender"]),
                        Address = row["Address"].ToString(),
                        Password = row["Password"].ToString()
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
            }
            return users;
        }

        public User GetUserById(int id)
        {
            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                string databaseName = "moocdb";
                string tableName = "user";

                string sql = $"SELECT Id, UserName, Email, Phone, Gender, Address, Password FROM {databaseName}.`{tableName}` WHERE Id = @id";                
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    
                    var user = new User
                    {
                        Id = reader.GetInt32("Id"),
                        UserName = reader.GetString("UserName"),
                        Email = reader.GetString("Email"),
                        Phone = reader.GetString("Phone"),
                        Gender = (GenderEnum)reader.GetInt32("Gender"),
                        Address = reader.GetString("Address"),
                        Password = reader.GetString("Password")
                    };
                    #region Debug
                    Console.WriteLine($"Debug 1: User data {user}");
                    #endregion

                    return user;

                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error with the UserID: {ex.Message}");
                return null;
            }

        }

        public List<User> GetAllUserWithDataReader()
        {
            List<User> users = new List<User>();
            string databaseName = "moocdb";
            string tableName = "user";

            try
            {
                using var connection = new MySqlConnection(_connectionString);
                connection.Open();

                string sql = $"SELECT * FROM {databaseName}.`{tableName}` WHERE 1 = @parm";
                using var command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@parm", 1);

                using var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        Id = reader.GetInt32("Id"),
                        UserName = reader.GetString("UserName"),
                        Email = reader.GetString("Email"),
                        Phone = reader.GetString("Phone"),
                        Gender = (GenderEnum)reader.GetInt32("Gender"),
                        Address = reader.GetString("Address"),
                        Password = reader.GetString("Password")
                    };
                    users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
            }
            return users;
        }



        public List<User> GetAllUsersWithDataAdapter()
        {
            List<User> users = new List<User>();
            string databaseName = "moocdb";
            string tableName = "user";

            try
            {
                using var connection = new MySqlConnection(_connectionString);

                string sql = $"SELECT * FROM {databaseName}.`{tableName}` WHERE 1 = @param";
                using var command = new MySqlCommand(sql, connection);
                
                #region Debug
                Console.WriteLine($"Debug1: {command}");
                #endregion
                
                command.Parameters.AddWithValue("@param", 1);

                using var adapter = new MySqlDataAdapter(command);

                #region Debug
                Console.WriteLine($"Debug2: {adapter}");
                #endregion

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    User user = new User
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        UserName = row["UserName"].ToString(),
                        Email = row["Email"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Gender = (GenderEnum)Convert.ToInt32(row["Gender"]),
                        Address = row["Address"].ToString(),
                        Password = row["Password"].ToString()
                    };
                    #region Debug
                    Console.WriteLine($"Debug3: {user}");
                    #endregion

                    users.Add(user);
                }
                #region Debug
                Console.WriteLine("Service Script: Users retreived successfully");
                #endregion
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving users: {ex.Message}");
            }
            return users;
        }

    }

}
