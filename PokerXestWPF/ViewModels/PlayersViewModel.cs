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
    public class PlayersViewModel : ViewModelBase
    {

        //Campos
        private string _playerDni;
        private string _playerNickname;
        private string _playerName;
        private string _playerSurname;
        private string _playerPhoneNumber;
        private string _playerEmail;
        private string _playerBirthdayDate;  
        private IPlayerRepository playerRepository;
        private ViewModelBase _currenteChildView;
        private string _errorMessage;
        private bool _isViewVisible = true;
       
       
        
        //notificaciones
        //Comandos

       
        public ICommand SavePlayerCommand { get; }
       

        //Propiedades
        public string PlayerDni
        { get
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
                OnPropertyChanged(nameof(_playerNickname));
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
                OnPropertyChanged(nameof(_playerName));
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
                OnPropertyChanged(nameof(_playerSurname));
            }
        }
        public string PlayerPhoneNumber 
        { 
            get 
            {
                return _playerPhoneNumber; 
            }
            set 
            {
                _playerPhoneNumber = value; 
                OnPropertyChanged(nameof(_playerPhoneNumber));     
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
                OnPropertyChanged(nameof(_playerEmail));
            } 
        }
        public string PlayerBirthdayDate 
        { 
            get 
            { 
                return _playerBirthdayDate; 
            } 
            set 
            {
                _playerBirthdayDate = value; 
                OnPropertyChanged(nameof(_playerBirthdayDate));
            }
        }
        
        public ViewModelBase CurrenteChildView 
        { 
            get 
            { 
                return _currenteChildView; 
            }
            set 
            { 
                _currenteChildView = value; 
                OnPropertyChanged(nameof(_currenteChildView));
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
                OnPropertyChanged(nameof(_errorMessage));
            }
        }
        public bool IsViewVisible 
        { 
            get 
            { 
                return _isViewVisible; 
            }
            set 
            { 
                _isViewVisible = value; 
                OnPropertyChanged(nameof(_isViewVisible));
            }
        }

        public PlayersViewModel()
        {
            playerRepository = new PlayerRepository();
            //SavePlayerCommand = new ViewModelCommand(ExecuteSavePlayerCommand, CanExecuteSavePlayerCommand);
        }

        /* private bool CanExecuteSavePlayerCommand(object obj)
         {
             var isValidDni = playerRepository.IsValidDNI(new String (PlayerDni));
             //var isOver18 = playerRepository.IsOver18(new DateTime(PlayerBirthdayDate));

         }

         private void ExecuteSavePlayerCommand(object obj)
         {
             throw new NotImplementedException();
         }
        */
    }
}
