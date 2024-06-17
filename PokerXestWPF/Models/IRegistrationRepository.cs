using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public interface IRegistrationRepository
    {
        void Add(RegistrationModel registrationModel);
        void Remove(int id);
    }
}
