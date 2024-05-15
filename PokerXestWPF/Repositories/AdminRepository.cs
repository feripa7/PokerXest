using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class AdminRepository : RepositoryBase, IAdminRepository
    {
        public void Add(AdminModel adminModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateAdmin(NetworkCredential credential)
        {
            bool validAdmin;
            using(var connection = GetConnection())
            using (var command = new SqliteCommand()) 
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Admin] where dni=@dni and [password]=@password";
                command.Parameters.Add("@dni", SqliteType.Text).Value = credential.UserName;
                command.Parameters.Add("@password", SqliteType.Text).Value = credential.Password;
                validAdmin = command.ExecuteScalar() == null ? false : true;
            }
            return validAdmin;

        }

        public void Edit(AdminModel adminModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AdminModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public AdminModel GetByDni(string dni)
        {
            AdminModel admin = null;
            using (var connection = GetConnection())
            using (var command = new SqliteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Admin] where dni=@dni";
                command.Parameters.Add("@dni", SqliteType.Text).Value = dni;
                using(var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        admin = new AdminModel()
                        {
                            Dni = reader[0].ToString(),
                            Name = reader[1].ToString(),
                            Surname = reader[2].ToString(),
                            Email = reader[3].ToString(),
                            Password = string.Empty,
                        };
                    }
                }
            }
            return admin;
        }

        public void Remove(string dni)
        {
            throw new NotImplementedException();
        }
    }
}
