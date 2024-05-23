using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class PlayerRepository : RepositoryBase, IPlayerRepository
    {
        public void Add(PlayerModel playerModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(PlayerModel playerModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PlayerModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public PlayerModel GetByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public PlayerModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(string dni)
        {
            throw new NotImplementedException();
        }
    }
}
