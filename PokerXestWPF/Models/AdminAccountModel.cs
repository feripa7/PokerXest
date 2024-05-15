using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.Models
{
    public class AdminAccountModel
    {
        public string Dni {  get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public byte[] ProfilePicture { get; set; } 
    }
}
