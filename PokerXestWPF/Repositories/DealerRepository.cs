using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Repositories
{
    public class DealerRepository : RepositoryBase, IDealerRepository
    {
        public void Add(DealerModel dealerModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(DealerModel dealerModel)
        {
            throw new NotImplementedException();
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
