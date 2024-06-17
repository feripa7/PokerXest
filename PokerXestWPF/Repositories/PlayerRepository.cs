using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PokerXestWPF.Repositories
{
    public class PlayerRepository : RepositoryBase, IPlayerRepository
    {
        public void Add(PlayerModel playerModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Player (dni, nickName, name, surname, phoneNumber, email, birthdayDate) 
                    VALUES (@dni, @nickName, @name, @surname, @phoneNumber, @email, @birthdayDate)";
                    
                    command.Parameters.Add("@dni", SqliteType.Text).Value = playerModel.Dni;
                    command.Parameters.Add("@nickName", SqliteType.Text).Value = playerModel.NickName;
                    command.Parameters.Add("@name", SqliteType.Text).Value = playerModel.Name;
                    command.Parameters.Add("@surname", SqliteType.Text).Value = playerModel.Surname;
                    command.Parameters.Add("@phoneNumber", SqliteType.Integer).Value = playerModel.PhoneNumber;
                    command.Parameters.Add("@email", SqliteType.Text).Value = playerModel.Email;
                    command.Parameters.Add("@birthdayDate", SqliteType.Text).Value = playerModel.BirthdayDate;

                    command.ExecuteNonQuery();

                }
            }
        }

        public void Edit(PlayerModel playerModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Player (nickName, name, surname, phoneNumber, email, birthdayDate) 
                    VALUES (@nickName, @name, @surname, @phoneNumber, @email, @birthdayDate)";
                  
                    command.Parameters.Add("@nickName", SqliteType.Text).Value = playerModel.NickName;
                    command.Parameters.Add("@name", SqliteType.Text).Value = playerModel.Name;
                    command.Parameters.Add("@surname", SqliteType.Text).Value = playerModel.Surname;
                    command.Parameters.Add("@phoneNumber", SqliteType.Integer).Value = playerModel.PhoneNumber;
                    command.Parameters.Add("@email", SqliteType.Text).Value = playerModel.Email;
                    command.Parameters.Add("@birthdayDate", SqliteType.Text).Value = playerModel.BirthdayDate;
                    command.ExecuteNonQuery();
                }
            }
        }

        public HashSet<PlayerModel> SearchFilter(string dni, string name, string surname)
        {
            HashSet<PlayerModel> filteredPlayers = new HashSet<PlayerModel>();
            using (var connection = GetConnection())
            using (var command = new SqliteCommand())
            {
                connection.Open();
                command.Connection = connection;
                string query = "SELECT * FROM [Player] WHERE 1=1";

                if (!string.IsNullOrEmpty(dni))
                {
                    query += " AND dni = @dni";
                    command.Parameters.Add("@dni", SqliteType.Text).Value = dni;
                }

                if (!string.IsNullOrEmpty(name))
                {
                    query += " AND name = @name";
                    command.Parameters.Add("@name", SqliteType.Text).Value = name;
                }

                if (!string.IsNullOrEmpty(surname))
                {
                    query += " AND surname = @surname";
                    command.Parameters.Add("@surname", SqliteType.Text).Value = surname;
                }

                command.CommandText = query;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var player = new PlayerModel()
                        {
                            Dni = reader["dni"].ToString(),
                            NickName = reader["nickName"].ToString(),
                            Name = reader["name"].ToString(),
                            Surname = reader["surname"].ToString(),
                            PhoneNumber = Convert.ToInt32(reader["phoneNumber"]),
                            Email = reader["email"].ToString(),
                            BirthdayDate = DateTime.Parse(reader["birthdayDate"].ToString())
                        };
                        filteredPlayers.Add(player);
                    }
                }
            }

            return filteredPlayers;
        }
   

        public PlayerModel GetByDni(string dni)
        {
            PlayerModel player = null;
            using (var connection = GetConnection())
            using (var command = new SqliteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Player] where dni=@dni";
                command.Parameters.Add("@dni", SqliteType.Text).Value = dni;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        player = new PlayerModel()
                        {
                            Dni = reader[0].ToString(),
                            NickName = reader[1].ToString(),
                            Name = reader[2].ToString(),
                            Surname = reader[3].ToString(),
                            PhoneNumber = (int)reader[4],
                            Email = reader[5].ToString(),
                            BirthdayDate = DateTime.Parse(reader[6].ToString()),
                        };
                    }
                }
            }
            return player;
        }

        public PlayerModel GetByName(string name)
        {
            PlayerModel player = null;
            using (var connection = GetConnection())
            using (var command = new SqliteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Player] where name=@name";
                command.Parameters.Add("@name", SqliteType.Text).Value = name;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        player = new PlayerModel()
                        {
                            Dni = reader[0].ToString(),
                            NickName = reader[1].ToString(),
                            Name = reader[2].ToString(),
                            Surname = reader[3].ToString(),
                            PhoneNumber = (int)reader[4],
                            Email = reader[5].ToString(),
                            BirthdayDate = DateTime.Parse(reader[6].ToString()),
                        };
                    }
                }
            }
            return player;
        }

        public bool DniExists(string dni)
        {
            bool dniExists;
            using (var connection = GetConnection())
            using (var command = new SqliteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Player] WHERE dni = @dni";
                command.Parameters.Add("@dni", SqliteType.Text).Value = dni;
                dniExists = command.ExecuteScalar() == null ? false : true; 
            }
            return dniExists;
        }

        public bool IsValidDNI(string dni)
        {
            Regex dniRegex = new Regex(@"^\d{8}[A-HJ-NP-TV-Z]$");
            return dniRegex.IsMatch(dni);
        }

        public char CalculateDNILetter(int numbers)
        {
            string letters = "TRWAGMYFPDXBNJZSQVHLCKE";
            return letters[numbers % 23];
        }
     
        public bool IsOver18(DateTime fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;
            int edad = fechaActual.Year - fechaNacimiento.Year;

            if (fechaActual.Month < fechaNacimiento.Month || (fechaActual.Month == fechaNacimiento.Month && fechaActual.Day < fechaNacimiento.Day))
            {
                edad--;
            }

            return edad >= 18;
        }


        public void Remove(string dni)
        {
            if (!DniExists(dni))
            {
                throw new ArgumentException("El DNI proporcionado no existe en la base de datos.");
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Player WHERE dni = @dni";
                    command.Parameters.Add("@dni", SqliteType.Text).Value = dni;
                    command.ExecuteNonQuery();
                }
            }
        }      
    }
}
