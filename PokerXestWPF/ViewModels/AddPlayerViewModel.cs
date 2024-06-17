using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerXestWPF.ViewModels
{
    public class AddPlayerViewModel : ViewModelBase
    {
        private string _playerDni;
        private string _playerNickname;
        private string _playerName;
        private string _playerSurname;
        private int _playerPhonenumber;
        private string _playerEmail;
        private DateTime _playerBirthday;
        private IPlayerRepository playerRepository;
        private string _errorMessage;

        public string PlayerDni 
        { 
            get
            { 
                return _playerDni; 
            } 
            set 
            { 
                _playerDni = value;
                OnPropertyChanged(nameof(PlayerDni));
            }
        }
        public string PlayerNickname
        { 
            get 
            {
                return _playerNickname; 
            } 
            set 
            {
                _playerNickname = value;
                OnPropertyChanged(nameof(PlayerNickname));
            } 
        }
        public string PlayerName
        {
            get
            { 
                return _playerName; 
            }
            set 
            {
                _playerName = value; 
                OnPropertyChanged(nameof(PlayerName));
            }
        }
        public string PlayerSurname 
        { 
            get 
            {
                return _playerSurname; 
            }
            set 
            { 
                _playerSurname = value; 
                OnPropertyChanged(nameof(PlayerSurname));
}        }
        public int PlayerPhonenumber 
        { 
            get 
            {
                return _playerPhonenumber; 
            }
            set 
            {
                _playerPhonenumber = value; 
                OnPropertyChanged(nameof(PlayerPhonenumber));
            }
        }
        public string PlayerEmail 
        { 
            get 
            {
                return _playerEmail; 
            } 
            set 
            {
                _playerEmail = value; 
                OnPropertyChanged(nameof(PlayerEmail));
            } 
        }
        public DateTime PlayerBirthday 
        { 
            get
            { 
                return _playerBirthday; 
            }
            set 
            { 
                _playerBirthday = value; 
                OnPropertyChanged(nameof(PlayerBirthday));
            } 
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand SaveCommand { get; }

        public AddPlayerViewModel()
        {
            playerRepository = new PlayerRepository();
            SaveCommand = new ViewModelCommand(ExecuteSaveCommand);
        }

        private void ExecuteSaveCommand(object obj)
        {
            var isValidDni = playerRepository.IsValidDNI(PlayerDni);
            var isOver18 = playerRepository.IsOver18(PlayerBirthday);
            if (isValidDni && isOver18)
            {
                var player = new PlayerModel();
                player.Dni = PlayerDni;
                player.NickName = PlayerNickname;
                player.Name = PlayerName;
                player.Surname = PlayerSurname;
                player.PhoneNumber = PlayerPhonenumber;
                player.BirthdayDate = PlayerBirthday;
            }

        }
    }
}
