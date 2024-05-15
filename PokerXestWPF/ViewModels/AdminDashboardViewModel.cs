using PokerXestWPF.Models;
using PokerXestWPF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerXestWPF.ViewModels
{
   public class AdminDashboardViewModel : ViewModelBase
    {
        //Campos
        private AdminAccountModel _currentAdminAccount;
        private IAdminRepository adminRepository;

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

        public AdminDashboardViewModel()
        {
            adminRepository = new AdminRepository();
            CurrentAdminAccount = new AdminAccountModel();
            LoadCurrentAdminData();
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
