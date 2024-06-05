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
        AdminModel GetByDni(string dni);
       
    }
}
