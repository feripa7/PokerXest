using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public interface IAdminRepository
    {
        bool AuthenticateAdmin(NetworkCredential credential);
        void Add(AdminModel adminModel);
        void Edit(AdminModel adminModel);
        void Remove(string dni);

        AdminModel GetByDni(string dni);
        IEnumerable<AdminModel> GetByAll();
    }
}
