using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class RegistrationRepository : RepositoryBase, IRegistrationRepository
    {
        public void Add(RegistrationModel registrationModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Registration (playerId, tournamentId, date) 
                    VALUES (@playerId, @tournamentId, @date)";

                    command.Parameters.Add("@playerId", SqliteType.Text).Value = registrationModel.PlayerDni;
                    command.Parameters.Add("@tournamentId", SqliteType.Text).Value = registrationModel.TournamentID;
                    command.Parameters.Add("@date", SqliteType.Text).Value = registrationModel.TournamentDate;

                    command.ExecuteNonQuery();

                }
            }
        }

        public void Remove(int id)
        {
            if (!IdExists(id))
            {
                throw new ArgumentException("El ID proporcionado no existe en la base de datos.");
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM Registration WHERE id = @id";
                    command.Parameters.Add("@id", SqliteType.Text).Value = id;
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IdExists(int id)
        {
            bool idExists;
            using (var connection = GetConnection())
            using (var command = new SqliteCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from [Registration] WHERE id = @id";
                command.Parameters.Add("@id", SqliteType.Text).Value = id;
                idExists = command.ExecuteScalar() == null ? false : true;
            }
            return idExists;
        }

    }
}
