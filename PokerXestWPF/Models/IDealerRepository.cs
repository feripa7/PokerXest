using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public interface IDealerRepository
    {
        void Add(DealerModel dealerModel);
        void Edit(DealerModel dealerModel);
        void Remove(string dni);
        bool DniExists(string dni);
        bool IsValidDNI(string dni);

        DealerModel GetByDni(string dni);
        IEnumerable<DealerModel> GetByAll();
    }
}
