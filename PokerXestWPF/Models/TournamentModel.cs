using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public class TournamentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public DateTime Time { get; set; }
        public double Comision { get; set; }
        public int MinLevel { get; set; }
        public int ReentryLvl { get; set; }
        public DateTime LateReg { get; set; }
        public double Price { get; set; }
        public double Blinds { get; set; }
        public int Sb {  get; set; }
        public int Bb { get; set; }
        public int Ante { get; set; }
    }
}
