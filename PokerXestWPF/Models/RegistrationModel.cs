using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string PlayerDni {  get; set; }
        public int TournamentID { get; set; }
        public DateTime TournamentDate { get; set; }
    }
}
