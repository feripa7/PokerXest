using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class DealerWorkloadRepository : RepositoryBase, IDealerWorkloadRepository
    {
        public void Add(DealerWorkloadModel dealerWorkloadModel)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO DealerTournament (dealerId, tournamentId, date) 
                    VALUES (@dealerId, @tournamentId, @date)";

                    command.Parameters.Add("@dealerId", SqliteType.Text).Value = dealerWorkloadModel.DealerDni;
                    command.Parameters.Add("@tournamentId", SqliteType.Text).Value = dealerWorkloadModel.TournamentID;
                    command.Parameters.Add("@date", SqliteType.Text).Value = dealerWorkloadModel.TournamentDate;

                    command.ExecuteNonQuery();

                }
            }
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
