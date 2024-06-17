using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public class DealerWorkloadModel
    {
        public int Id { get; set; }
        public string DealerDni { get; set; }
        public int TournamentID { get; set; }
        public DateTime TournamentDate { get; set; }

    }
}
