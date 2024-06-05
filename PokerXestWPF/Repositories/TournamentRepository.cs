using Microsoft.Data.Sqlite;
using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class TournamentRepository: RepositoryBase, ITournamentModel
    {
        public void Add(TournamentModel tournamentModel)
        {
            
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
  
        public void Remove(string dni)
        {
            throw new NotImplementedException();
        }

        public TournamentModel GetByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TournamentModel> GetByAll()
        {
            throw new NotImplementedException();
        }
    }
}
