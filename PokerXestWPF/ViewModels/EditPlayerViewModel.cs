using PokerXestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.ViewModels
{
    public class EditPlayerViewModel : ViewModelBase
    {
        private string _playerDni;
        private string _playerNickname;
        private string _playerName;
        private string _playerSurname;
        private int _playerPhonenumber;
        private string _playerEmail;
        private DateTime _playerBirthday;
        private IPlayerRepository playerRepository;

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
            }
        }
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


    }
}
