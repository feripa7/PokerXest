using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
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

                }
            }
        }

        public void Edit(PlayerModel playerModel)
        {
            throw new NotImplementedException();
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
                            BirthdayDate = DateOnly.Parse(reader["birthdayDate"].ToString())
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
                            BirthdayDate = DateOnly.Parse(reader[6].ToString()),
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
                            BirthdayDate = DateOnly.Parse(reader[6].ToString()),
                        };
                    }
                }
            }
            return player;
        }

        public void Remove(string dni)
        {
            throw new NotImplementedException();
        }
    }
}
