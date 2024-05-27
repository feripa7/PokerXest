using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerXestWPF.ViewModels
{
    public class PlayersViewModel : ViewModelBase
    {

        //Campos
        IEnumerable<PlayerModel> players;
        IPlayerRepository playerRepository;
        ViewModelBase _currenteChildView;
        //Propiedades
        //notificaciones
        //Comandos

        public ICommand ShowPlayersForm { get; }
        public ICommand SearchPlayers { get; }
        public ICommand ModifyPlayer { get; }
        public ICommand DeletePlayer { get; }

    }
}
