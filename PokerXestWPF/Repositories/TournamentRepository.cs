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
    public class TournamentRepository: RepositoryBase, ITournamentModel
    {
        public void Add(TournamentModel tournamentModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Tournament (name, date, time, comision, minLevel, price) 
                    VALUES (@name, @date, @time, @comision, @minLevel, @price)";

                    command.Parameters.Add("@name", SqliteType.Text).Value = tournamentModel.Name;
                    command.Parameters.Add("@date", SqliteType.Text).Value = tournamentModel.Date;
                    command.Parameters.Add("@time", SqliteType.Text).Value = tournamentModel.Time;
                    command.Parameters.Add("@comision", SqliteType.Text).Value = tournamentModel.Comision;
                    command.Parameters.Add("@minLevel", SqliteType.Integer).Value =  tournamentModel.MinLevel;
                    command.Parameters.Add("@price", SqliteType.Text).Value = tournamentModel.Price;                    

                    command.ExecuteNonQuery();

                }
            }
        }

        public void Edit(TournamentModel tournamentModel)
        {
            throw new NotImplementedException();
        }
        //Registro de xogadores
        public void PlayerLog(string playerDni, int tournamentId) 
        {
            
        }

        public void DealerParticipation(string dealerDni, int tournamentId)
        { 
        
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
                    command.CommandText = "DELETE FROM Tournament WHERE id = @id";
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
                command.CommandText = "select * from [Tournament] WHERE id = @id";
                command.Parameters.Add("@id", SqliteType.Text).Value = id;
                idExists = command.ExecuteScalar() == null ? false : true;
            }
            return idExists;
        }

        public TournamentModel GetByDni(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TournamentModel> GetByAll()
        {
            throw new NotImplementedException();
        }
    }
}
