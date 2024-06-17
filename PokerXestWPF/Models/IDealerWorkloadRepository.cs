using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public interface IDealerWorkloadRepository
    {
        void Add(DealerWorkloadModel dealerWorkloadModel);
        void Remove(int id);
    }
}
