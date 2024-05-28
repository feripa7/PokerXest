using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public interface IPlayerRepository
    {
        void Add(PlayerModel playerModel);
        void Edit(PlayerModel playerModel);
        void Remove(string dni);

        PlayerModel GetByDni(string dni);
        PlayerModel GetByName(string name);

        HashSet<PlayerModel> SearchFilter(string dni, string name, string surname);
    }
}
