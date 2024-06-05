using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public interface ITournamentModel
    {
        void Add(TournamentModel tournamentModel);
        void Edit(TournamentModel tournamentModel);
        void Remove(string dni);
        void PlayerLog(string playerDni, int tournamentId);
        void DealerParticipation(string dealerDni, int tournamentId);
        TournamentModel GetByDni(string dni);
        IEnumerable<TournamentModel> GetByAll();
    }
}
