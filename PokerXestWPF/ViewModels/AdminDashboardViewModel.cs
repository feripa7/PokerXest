using FontAwesome.Sharp;
using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using PokerXestWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PokerXestWPF.ViewModels
{
   public class AdminDashboardViewModel : ViewModelBase
    {
        //Campos
        private AdminAccountModel _currentAdminAccount;
        private IAdminRepository adminRepository;
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;


        //Propiedades
        public AdminAccountModel CurrentAdminAccount
        {
            get
            {
                return _currentAdminAccount;
            }
            set
            {
                _currentAdminAccount = value;
                OnPropertyChanged(nameof(CurrentAdminAccount));
            }

        }

        public ViewModelBase CurrentChildView 
        { 
            get 
            {
                return _currentChildView; 
            }
            set 
            { 
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption {  
            get 
            { 
                return _caption; 
            }
            set
            {
                _caption = value; 
                OnPropertyChanged(nameof(Caption));
            }
        } 
        public IconChar Icon { 
            get 
            {
                return _icon; 
            }
            set 
            { 
                _icon = value; 
                OnPropertyChanged(nameof(Icon));
            }
        }

        //Comandos
        public ICommand ShowDashboardViewCommand { get; }
        public ICommand ShowPlayersViewCommand { get; }
        public ICommand ShowDealersViewCommand { get; }
        public ICommand ShowFinancialsViewCommand { get; }
        public ICommand ShowTournamentsViewCommand { get; }
        public ICommand LogOutCommand { get; }

       

        public AdminDashboardViewModel()
        {
            adminRepository = new AdminRepository();
            CurrentAdminAccount = new AdminAccountModel();

            //Inicializamos comandos
            ShowDashboardViewCommand = new ViewModelCommand(ExecuteShowDashboardViewCommand);
            ShowPlayersViewCommand = new ViewModelCommand(ExecuteShowPlayersViewCommand);
            ShowDealersViewCommand = new ViewModelCommand(ExecuteShowDealersViewCommand);
            ShowFinancialsViewCommand = new ViewModelCommand(ExecuteShowFinancialsViewCommand);
            ShowTournamentsViewCommand = new ViewModelCommand(ExecuteShowTournamentsViewCommand);

            //Vista por defecto
            ExecuteShowDashboardViewCommand(null);

            LoadCurrentAdminData();
        }

        private void ExecuteShowTournamentsViewCommand(object obj)
        {
            CurrentChildView = new TournamentsViewModel();
            Caption = "Torneos";
            Icon = IconChar.Calendar;
        }

        private void ExecuteShowFinancialsViewCommand(object obj)
        {
            CurrentChildView = new FinancialsViewModel();
            Caption = "Finanzas";
            Icon = IconChar.Wallet;
        }

        private void ExecuteShowDealersViewCommand(object obj)
        {
            CurrentChildView = new DealersViewModel();
            Caption = "Repartidores";
            Icon = IconChar.Diamond;
        }

        private void ExecuteShowPlayersViewCommand(object obj)
        {
            CurrentChildView = new PlayersViewModel();
            Caption = "Xogadores";
            Icon = IconChar.UserGroup;
        }

        private void ExecuteShowDashboardViewCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
            Caption = "Panel de control";
            Icon = IconChar.House;
        }

        private void ExecuteLogOutCommand(object obj) 
        {
            CurrentChildView = new LoginViewModel();        
        }

        private void LoadCurrentAdminData()
        {
            var admin = adminRepository.GetByDni(Thread.CurrentPrincipal.Identity.Name);
            if (admin != null)
            {

                CurrentAdminAccount.Dni = admin.Dni;
                CurrentAdminAccount.DisplayName = $"Benvido, {admin.Name} {admin.Surname}";
                CurrentAdminAccount.ProfilePicture = null;
                
            }
            else
            {
                CurrentAdminAccount.DisplayName = "Administrador non válido, non iniciou sesión";
            }
        }
    }
}
