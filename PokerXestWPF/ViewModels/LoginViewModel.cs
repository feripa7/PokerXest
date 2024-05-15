using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerXestWPF.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        //Campos
        private string _adminDni;
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;


        private IAdminRepository adminRepository;

        //Propiedades
        public string AdminDni 
        { 
            get 
            { 
                return _adminDni; 
            }
            set
            {
                _adminDni = value;
                OnPropertyChanged(nameof(AdminDni));
            }
        }
        public SecureString Password 
        {
            get
            {
                return _password; 
            }
            set 
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
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
        public bool IsViewVisible 
        { 
            get 
            {
                return _isViewVisible; 
            } 
            set 
            { 
                _isViewVisible = value; 
                OnPropertyChanged(nameof(IsViewVisible));
            }
        }

        //Comandos

        public ICommand LoginCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        //Constructor

        public LoginViewModel() 
        {
            adminRepository = new AdminRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            
        }     

        private void ExecuteLoginCommand(object obj)
        {
            var isValidAdmin = adminRepository.AuthenticateAdmin(new NetworkCredential(AdminDni, Password));
            if(isValidAdmin)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(
                    new GenericIdentity(AdminDni), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "* DNI ou contrasinal incorrectos";
            }
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (String.IsNullOrWhiteSpace(AdminDni) || AdminDni.Length < 9 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;
            return validData;
        }
    }
}
