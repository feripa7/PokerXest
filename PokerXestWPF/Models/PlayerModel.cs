using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public class PlayerModel
    {
        public string Dni { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthdayDate { get; set; }
    }
}
