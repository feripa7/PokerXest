using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class DealerRepository : RepositoryBase, IDealerRepository
    {
        public void Add(DealerModel dealerModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Dealer (dni, name, surname, email) 
                    VALUES (@dni, @name, @surname, @email)";

                    command.Parameters.Add("@dni", SqliteType.Text).Value = dealerModel.Dni;
                    command.Parameters.Add("@name", SqliteType.Text).Value = dealerModel.Name;
                    command.Parameters.Add("@surname", SqliteType.Text).Value = dealerModel.Surname;
                    command.Parameters.Add("@email", SqliteType.Text).Value = dealerModel.Email;

                    command.ExecuteNonQuery();

                }
            }
        }

        public void Edit(DealerModel dealerModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Player (name, surname, email) 
                    VALUES (@name, @surname, @email)";

                    
                    command.Parameters.Add("@name", SqliteType.Text).Value = dealerModel.Name;
                    command.Parameters.Add("@surname", SqliteType.Text).Value = dealerModel.Surname;     
                    command.Parameters.Add("@email", SqliteType.Text).Value = dealerModel.Email;
                   
                    if (DniExists("@dni"))
                    {
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("DNI no válido");
                    }

                }
            }
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

        public IEnumerable<DealerModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public DealerModel GetByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public void Remove(string dni)
        {
            throw new NotImplementedException();
        }
    }
}
